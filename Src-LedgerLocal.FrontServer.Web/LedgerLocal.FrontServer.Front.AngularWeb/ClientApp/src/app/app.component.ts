import { Component, OnInit, ViewContainerRef, AfterViewInit, OnDestroy, Inject, PLATFORM_ID } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import { ContentService } from './@core/data/contentservice';
import { OnlineService } from './@core/data/onlineservice';
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

  userDataSubscription: Subscription;
  public userData: any;
  public userName: string;
  public labelLoggin = 'Login';

  token: string;

  hash: string;
  isFirstLogged: boolean;

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    public toastr: ToastsManager,
    public vRef: ViewContainerRef,
    public oidcSecurityService: OidcSecurityService,
    private analytics: AnalyticsService,
    private cntService: ContentService,
    private onlineService: OnlineService,
    private router: Router) {
    
    this.toastr.setRootViewContainerRef(vRef);

    if (this.oidcSecurityService.moduleSetup) {
      this.doCallbackLogicIfRequired();
    } else {
      this.oidcSecurityService.onModuleSetup.subscribe(() => {
        this.doCallbackLogicIfRequired();
      });
    }

    this.oidcSecurityService.onAuthorizationResult.subscribe(
      (authorizationResult: AuthorizationResult) => {
        this.onAuthorizationResultComplete(authorizationResult);
      });

  }

  ngOnInit(): void {
    //this.analytics.trackPageViews();
    this.router.initialNavigation();

    this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
      (isAuthorized: boolean) => {
        this.isAuthorized = isAuthorized;

        if (this.isAuthorized) {

          var refthis = this;

          this.userDataSubscription = this.oidcSecurityService.getUserData().subscribe(
            (userData: any) => {

              refthis.userData = userData;

              if (refthis.userData) {

                refthis.cntService.addAuth(refthis.userData);

                refthis.userName = refthis.userData.name;

                if (refthis.userName) {

                  refthis.labelLoggin = refthis.userName.split('@')[0];

                }

              }

            });
        }
      });

  }

  public handleError(error: Response) {
    this.toastr.error("Error occured !");
    return Observable.throw(error.json() || 'Server error');
  }

  ngAfterViewInit() {

    var signalR = require("../../scripts/signalr.js");

    const connection = new signalR.HubConnectionBuilder()
      .withUrl("/rtllc")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    connection.on('online', data => {

      this.onlineService.sendMessage(Number(data));
      this.toastr.info("Online => " + data);

    });

    //connection.on('blockNumberRefresh', data => {
    //  //InvokeAsync("blockNumberRefresh",  new { HeadBlockNumber = fO1.HeadBlockNumber, HeadBlockId = idLadtBlock, CurrentWitness = fO1.CurrentWitness, LastActiveMobile = numLastMobileUSer });
    //  this.lcBlockService.sendMessage(Number(data.headBlockNumber), data.headBlockId, data.currentWitness, Number(data.lastActiveMobile));
    //});

    //connection.on('lycStatRefresh', data => {

    //  this.lcLsService.sendMessage(Number(data.totalUsers), Number(data.allPoints), data.lastCoinLedgerList);

    //});

    connection.start();

  }

  ngOnDestroy(): void {
    //this.isAuthorizedSubscription.unsubscribe();
    this.oidcSecurityService.onModuleSetup.unsubscribe();
  }

  private onAuthorizationResultComplete(authorizationResult: AuthorizationResult) {
    console.log('AppComponent:onAuthorizationResultComplete' + authorizationResult.toString());
    this.router.navigate(['/pages/userdetail/userdetail-view']);

    //const path = this.read('redirect');
    //if (authorizationResult === AuthorizationResult.authorized) {
    //  this.router.navigate([path]);
    //} else {
    //  this.router.navigate(['/unauthorized']);
    //}
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
