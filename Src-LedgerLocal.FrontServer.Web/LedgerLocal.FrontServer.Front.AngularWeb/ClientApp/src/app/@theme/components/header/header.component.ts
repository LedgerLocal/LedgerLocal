import { Component, Input, OnInit, AfterViewInit, OnDestroy } from '@angular/core';

import { NbMenuService, NbSidebarService } from '@nebular/theme';
import { UserService } from '../../../@core/data/users.service';
import { AnalyticsService } from '../../../@core/utils/analytics.service';
import { ContentService } from '../../../@core/data/contentservice';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { OidcSecurityService, AuthorizationResult } from 'angular-auth-oidc-client';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { Router, NavigationStart } from '@angular/router';
import * as _ from 'lodash';

@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, AfterViewInit, OnDestroy {
  
  @Input() position = 'normal';

  user: any;

  userMenu = [{ title: 'Profile' }, { title: 'Log out' }];

  contentBlockList: any;

  subscription: Subscription;
  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;
  userDataSubscription: Subscription;
  initAuthSubscription: Subscription;
  public userData: any;
  public userName: string;
  token: string;
  public loginUrl: string;
  private boolVal: boolean;

  constructor(private sidebarService: NbSidebarService,
              private menuService: NbMenuService,
              private userService: UserService,
              private analyticsService: AnalyticsService,
              private contentS: ContentService,
              private layoutInit: LayoutInitService,
              private router: Router,
              public oidcSecurityService: OidcSecurityService,
              public toastr: ToastsManager) {

    this.userData = null;
    this.userName = "Not logged";
    this.loginUrl = "/pages/home";
    this.boolVal = false;
  }

  ngOnInit() {
    //console.log('IsAuthorized:' + this.isAuthorized);

    var refthis = this;

    this.initAuthSubscription = this.contentS.getAuth().subscribe((auth1: any) => {

      if (auth1) {

        refthis.userData = auth1;
        refthis.userName = auth1.name;
        refthis.boolVal = true;
      }

    });
  }

  ngOnDestroy(): void {

  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    return false;
  }

  toggleSettings(): boolean {
    this.sidebarService.toggle(false, 'settings-sidebar');
    return false;
  }

  goToHome(): void {
    this.router.navigate(['/pages/home/home-view']);
  }

  ngAfterViewInit() {
  }

  loginOrLogoff() {

    if (this.boolVal) {
      this.oidcSecurityService.logoff();
    } else {
      
    }

    return false;
    //this.menuService.navigateHome();
  }

  startSearch() {
    //this.analyticsService.trackEvent('startSearch');
  }

}
