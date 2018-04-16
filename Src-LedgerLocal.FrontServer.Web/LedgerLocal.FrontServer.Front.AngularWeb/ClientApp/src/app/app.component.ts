/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnInit, ViewContainerRef, AfterViewInit, OnDestroy } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import { Router, NavigationStart } from '@angular/router';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { OidcSecurityService, AuthorizationResult } from 'angular-auth-oidc-client';
import 'rxjs/add/operator/filter';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy, AfterViewInit  {

  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;
  hash: string;

  constructor(
    public toastr: ToastsManager, vRef: ViewContainerRef, public oidcSecurityService: OidcSecurityService,
    private analytics: AnalyticsService,
    private router: Router) {

    this.toastr.setRootViewContainerRef(vRef);

    if (this.oidcSecurityService.moduleSetup) {
      this.doCallbackLogicIfRequired();
    } else {
      this.oidcSecurityService.onModuleSetup.subscribe(() => {
        this.doCallbackLogicIfRequired();
      });
    }

    this.router.events.filter((event: any) => event instanceof NavigationStart)
      .subscribe((data: NavigationStart) => {
        if (data.url == "/access_token") {
          this.hash = window.location.hash;
          this.router.navigate([]);
        }
      });

    this.oidcSecurityService.onAuthorizationResult.subscribe(
      (authorizationResult: AuthorizationResult) => {
        this.onAuthorizationResultComplete(authorizationResult);
      });
  }

  ngOnInit(): void {
    this.analytics.trackPageViews();

    this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
      (isAuthorized: boolean) => {
        this.isAuthorized = isAuthorized;
      });
  }

  public handleError(error: Response) {
    this.toastr.error("Error occured !");
    return Observable.throw(error.json() || 'Server error');
  }

  ngAfterViewInit() {

  }

  ngOnDestroy(): void {
    this.isAuthorizedSubscription.unsubscribe();
    this.oidcSecurityService.onModuleSetup.unsubscribe();
  }

  public login() {
    this.oidcSecurityService.authorize();
  }

  public logout() {
    this.oidcSecurityService.logoff();
  }

  private getTokenHash() {
    if (typeof location !== 'undefined' && this.hash) {
      const indexHash = this.hash.indexOf('/access_token');
      return indexHash > -1 && this.hash.substr(indexHash);
    }
  }

  private doCallbackLogicIfRequired() {

    console.info("doCallbackLogicIfRequired");
    const hash = this.getTokenHash();
    if (hash) {
      this.oidcSecurityService.authorizedCallback(hash);
    }

  }

  private onAuthorizationResultComplete(authorizationResult: AuthorizationResult) {
    console.log('AppComponent:onAuthorizationResultComplete');
    const path = this.read('redirect');
    if (authorizationResult === AuthorizationResult.authorized) {
      this.router.navigate([path]);
    } else {
      this.router.navigate(['/unauthorized']);
    }
  }

  private read(key: string): any {
    const data = localStorage.getItem(key);
    if (data != null) {
      return JSON.parse(data);
    }

    return;
  }

  private write(key: string, value: any): void {
    localStorage.setItem(key, JSON.stringify(value));
  }

}
