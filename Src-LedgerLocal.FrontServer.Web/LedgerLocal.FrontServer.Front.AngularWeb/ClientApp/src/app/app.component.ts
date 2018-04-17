import { Component, OnInit, ViewContainerRef, AfterViewInit, OnDestroy, Inject, PLATFORM_ID } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import { Router, NavigationStart } from '@angular/router';

import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { OidcSecurityService, AuthorizationResult } from 'angular-auth-oidc-client';
import { isPlatformBrowser } from '@angular/common';
import 'rxjs/add/operator/filter';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy, AfterViewInit  {

  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;
  hash: string;
  isFirstLogged: boolean;

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
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

  }

  ngOnInit(): void {
    //this.analytics.trackPageViews();
    this.router.initialNavigation();

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

  getTokenHash() {
    if (typeof location !== 'undefined' && window.location.hash) {
      const indexHash = window.location.hash.indexOf('id_token');
      return indexHash > -1 && window.location.hash.substr(indexHash);
    }
  }

  private doCallbackLogicIfRequired() {

    if (isPlatformBrowser(this.platformId)) {

      console.info("doCallbackLogicIfRequired");
      const hash = this.getTokenHash();
      if (hash) {
        console.info("processing " + hash);
        this.oidcSecurityService.authorizedCallback(hash);
      }

    }
    
  }

}
