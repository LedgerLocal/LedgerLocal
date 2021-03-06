import { Component, OnDestroy, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { DomSanitizer, SafeResourceUrl, SafeUrl, SafeStyle } from '@angular/platform-browser';
import { ContentService } from '../../../@core/data/contentservice';
import { OidcSecurityService, AuthorizationResult } from 'angular-auth-oidc-client';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';

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

  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;
  initAuthSubscription: Subscription;
  public userData: any;
  public userName: string;
  public labelLoggin = 'Login';

  public contentBlockList: any;

  token: string;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private contentService: ContentService,
    private sanitization: DomSanitizer,
    public oidcSecurityService: OidcSecurityService,
    public toastr: ToastsManager) {
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

    this.initAuthSubscription = this.contentService.getAuth().subscribe((auth1: any) => {

      if (auth1) {
        this.userData = auth1;
        this.userName = auth1.name;
      }

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
