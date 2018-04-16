import { Component, Input, OnInit, AfterViewInit, OnDestroy } from '@angular/core';

import { NbMenuService, NbSidebarService } from '@nebular/theme';
import { UserService } from '../../../@core/data/users.service';
import { AnalyticsService } from '../../../@core/utils/analytics.service';
import { ContentService } from '../../../@core/data/contentservice';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { OidcSecurityService } from 'angular-auth-oidc-client';
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
  public userData: any;
  public userName: string;
  token: string;

  constructor(private sidebarService: NbSidebarService,
              private menuService: NbMenuService,
              private userService: UserService,
              private analyticsService: AnalyticsService,
              private contentS: ContentService,
              private layoutInit: LayoutInitService,
              public toastr: ToastsManager, public oidcSecurityService: OidcSecurityService) {

    this.userData = null;

  }

  ngOnInit() {
    this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
      (isAuthorized: boolean) => {
        this.isAuthorized = isAuthorized;
        if (this.isAuthorized) {

          this.token = this.oidcSecurityService.getToken();
          this.toastr.success("Authorized !");

          this.userDataSubscription = this.oidcSecurityService.getUserData().subscribe(
            (userData: any) => {

              this.userData = userData;
              this.userName = this.userData.name;

            });
        }
      });


    //console.log('IsAuthorized:' + this.isAuthorized);
  }

  ngOnDestroy(): void {
    this.isAuthorizedSubscription.unsubscribe();

    if (this.userDataSubscription) {
      this.userDataSubscription.unsubscribe();
    }
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    return false;
  }

  toggleSettings(): boolean {
    this.sidebarService.toggle(false, 'settings-sidebar');
    return false;
  }

  ngAfterViewInit() {
  }

  goToHome() {
    this.menuService.navigateHome();
  }

  startSearch() {
    this.analyticsService.trackEvent('startSearch');
  }

  public login() {
    this.oidcSecurityService.authorize();
  }

  public logout() {
    this.oidcSecurityService.logoff();
  }
}
