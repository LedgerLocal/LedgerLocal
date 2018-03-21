import { Component, Input, OnInit, AfterViewInit } from '@angular/core';

import { NbMenuService, NbSidebarService } from '@nebular/theme';
import { UserService } from '../../../@core/data/users.service';
import { AnalyticsService } from '../../../@core/utils/analytics.service';
import { ContentService } from '../../../@core/data/contentservice';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import * as _ from 'lodash';

@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, AfterViewInit {


  @Input() position = 'normal';

  user: any;

  userMenu = [{ title: 'Profile' }, { title: 'Log out' }];

  contentBlockList: any;

  constructor(private sidebarService: NbSidebarService,
              private menuService: NbMenuService,
              private userService: UserService,
              private analyticsService: AnalyticsService,
              private contentS: ContentService,
              private layoutInit: LayoutInitService) {
  }

  ngOnInit() {
    this.contentS.initContentList();
    this.contentS.getContentList()
      .subscribe((cb: any) => {
        this.contentBlockList = cb;
      });
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
}
