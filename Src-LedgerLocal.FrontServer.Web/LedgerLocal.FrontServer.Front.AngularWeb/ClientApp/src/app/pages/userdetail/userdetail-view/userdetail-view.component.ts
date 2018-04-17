import { Component, OnDestroy, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { DomSanitizer, SafeResourceUrl, SafeUrl, SafeStyle } from '@angular/platform-browser';
import { ContentService } from '../../../@core/data/contentservice';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-userdetail-view',
  templateUrl: './userdetail-view.component.html',
  styleUrls: ['./userdetail-view.component.scss']
})
export class UserDetailViewComponent implements OnInit, AfterViewInit {

  public contentBlockList: any;

  initAuthSubscription: Subscription;
  public userData: any;
  public userName: string;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private userService: ContentService,
    private sanitization: DomSanitizer,
    private router: Router) {
  }

  ngOnInit() {

    this.initAuthSubscription = this.userService.getAuth().subscribe((auth1: any) => {

      if (auth1) {
        this.userData = auth1;
        this.userName = auth1.name;
      }

    });

    //this.userService.initContentList();
    //this.userService.getContentList()
    //  .subscribe((cb: any) => {
    //    this.contentBlockList = cb;
    //  });
  }

  participateIco(): void {
    this.router.navigate(['/pages/participate/participate-view']);
  }

  ngAfterViewInit() {
    //this.loService.makeInit();
    //this.loService.scrollToTop();
  }

}
