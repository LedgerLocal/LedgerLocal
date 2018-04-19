import { Component, OnDestroy, OnInit, AfterViewInit, AfterViewChecked } from '@angular/core';
import { SmartTableService } from '../../../@core/data/smart-table.service';
import { LayoutInitService } from '../../../@core/data/layoutinit';
import { DomSanitizer, SafeResourceUrl, SafeUrl, SafeStyle } from '@angular/platform-browser';
import { ContentService } from '../../../@core/data/contentservice';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-participate-view',
  templateUrl: './participate-view.component.html',
  styleUrls: ['./participate-view.component.scss']
})
export class ParticipateViewComponent implements OnInit, AfterViewInit {

  public contentBlockList: any;
  initAuthSubscription: Subscription;
  public userData: any;
  public userName: string;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private userService: ContentService,
    private sanitization: DomSanitizer) {
  }

  ngOnInit() {

    var refthis = this;

    this.initAuthSubscription = this.userService.getAuth().subscribe((auth1: any) => {

      if (auth1) {
        console.log("[UserDetail] Setting user from observable");
        console.log(auth1);

        refthis.userData = auth1;
        refthis.userName = auth1.name;
      }

    });

  }

  ngAfterViewInit() {
    this.loService.makeInit();
    this.loService.scrollToTop();
  }

}
