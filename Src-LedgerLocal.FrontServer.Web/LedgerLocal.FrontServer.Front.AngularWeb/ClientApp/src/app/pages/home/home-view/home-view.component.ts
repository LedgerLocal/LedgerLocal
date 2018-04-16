import { Component, OnDestroy, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { DomSanitizer, SafeResourceUrl, SafeUrl, SafeStyle } from '@angular/platform-browser';
import { ContentService } from '../../../@core/data/contentservice';
import { OidcSecurityService, AuthorizationResult } from 'angular-auth-oidc-client';

@Component({
  selector: 'ngx-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.scss']
})
export class HomeViewComponent implements OnInit, AfterViewInit {

  public currentActive: Number;
  public totalHashingPower: Number;
  public averageHashingPower: Number;
  public currentInactive: string;
  public styleSlide1: SafeStyle;
  public styleSlide2: SafeStyle;
  public styleSlide3: SafeStyle;
  public styleSlide4: SafeStyle;
  
  public contentBlockList: any;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private contentService: ContentService,
    private sanitization: DomSanitizer,
    public oidcSecurityService: OidcSecurityService) {
    this.currentActive = 0;
    this.totalHashingPower = 0;
    this.averageHashingPower = 0;
    this.currentInactive = '';
  }

  ngOnInit() {
    this.contentService.initContentList();
    this.contentService.getContentList()
      .subscribe((cb: any) => {
        this.contentBlockList = cb;
      });
  }

  ngAfterViewInit() {
    this.loService.makeInit();
    this.loService.scrollToTop();
  }

  public login() {
    this.oidcSecurityService.authorize();
  }

  public logout() {
    this.oidcSecurityService.logoff();
  }

}
