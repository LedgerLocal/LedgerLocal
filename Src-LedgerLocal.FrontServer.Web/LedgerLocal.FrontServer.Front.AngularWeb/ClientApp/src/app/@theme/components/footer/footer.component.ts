import { Component, Input, OnInit } from '@angular/core';

import { NbMenuService, NbSidebarService } from '@nebular/theme';
import { UserService } from '../../../@core/data/users.service';
import { AnalyticsService } from '../../../@core/utils/analytics.service';
import { ContentService } from '../../../@core/data/contentservice';
import * as _ from 'lodash';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  templateUrl: './footer.component.html',
})

export class FooterComponent implements OnInit {


  @Input() position = 'normal';

  user: any;

  userMenu = [{ title: 'Profile' }, { title: 'Log out' }];

  contentBlockList: any;

  constructor(private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private userService: UserService,
    private analyticsService: AnalyticsService,
    private contentS: ContentService) {
  }

  ngOnInit() {
    this.contentS.initContentList();
    this.contentS.getContentList()
      .subscribe((cb: any) => {
        this.contentBlockList = cb;
      });
  }
}
