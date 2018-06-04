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
  public userData: any;
  public userName: string;
  public listCrypto: string[];
  public inputAddress: string;
  public inputCoinType: string;
  public amountRequested: number;
  public cryptoRequested: string;

  private initAuthSubscription: Subscription;

  constructor(private stService: SmartTableService,
    private loService: LayoutInitService,
    private userService: ContentService,
    private sanitization: DomSanitizer) {
  }

  ngOnInit() {

    this.amountRequested = 0;

  }

  ngAfterViewInit() {
    this.loService.makeInit();
    this.loService.scrollToTop();

    var refthis = this;

    this.stService.getAvailableCrypto().subscribe(res => {
      refthis.listCrypto = res;
    });

    var val1 = this.userService.getAuthValue();

    if (val1) {

      this.userData = val1;
      this.userName = val1.name;

    } else {

      this.initAuthSubscription = this.userService.getAuth().subscribe((auth1: any) => {

        if (auth1) {
          console.log("[UserDetail] Setting user from observable");
          console.log(auth1);

          refthis.userData = auth1;
          refthis.userName = auth1.name;
        }

      });

    }
  }

  executeParticipation() {

    var refthis = this;

    this.stService.initiateTrade(this.cryptoRequested, this.amountRequested).subscribe(res => {

      refthis.inputAddress = res.inputAddress;
      refthis.inputCoinType = res.inputCoinType;

    });

  }

}
