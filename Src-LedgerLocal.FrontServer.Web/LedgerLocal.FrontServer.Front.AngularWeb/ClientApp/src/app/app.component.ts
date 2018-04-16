/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnInit, ViewContainerRef, AfterViewInit, OnDestroy } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import 'rxjs/add/operator/filter';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { RouterModule, Routes, Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy, AfterViewInit  {

  hash: string;
  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;

  constructor(
    private router: Router,
    public toastr: ToastsManager,
    vRef: ViewContainerRef,
    public oidcSecurityService: OidcSecurityService,
    private analytics: AnalyticsService) {

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
        if (data.url == "/id_token") {
          this.hash = window.location.hash;
          this.router.navigate([]);
        }
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
      const indexHash = this.hash.indexOf('id_token');
      return indexHash > -1 && this.hash.substr(indexHash);
    }
  }

  private doCallbackLogicIfRequired() {

    const hash = this.getTokenHash();
    if (hash) {
      this.oidcSecurityService.authorizedCallback(hash);
    }

  }
}
