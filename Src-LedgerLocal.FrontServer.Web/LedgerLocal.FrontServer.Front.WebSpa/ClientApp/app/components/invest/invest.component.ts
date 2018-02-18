import { PLATFORM_ID, Component, AfterViewInit, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LayoutInitService } from '../../service/layoutinit';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { AgmCoreModule } from '@agm/core';
import { Subscription } from 'rxjs/Subscription';
import { BlockService } from '../../service/blockservice';
import { LycStatService } from '../../service/lycstatservice';

@Component({
    selector: 'invest',
    templateUrl: './invest.component.html'
})
export class InvestComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;
    private lcBlockService: BlockService;
    private lcLsService: LycStatService;
    public currentBlock = 0;

    public currentBlockId = "";
    public currentLastWitness = "";
    public currentLastMobileUser = 0;

    public currentMaxCoin = 0;
    public currentMaxUserCount = 0;
    public message: any;
    public subscription: Subscription;
    public subscriptionLycStat: Subscription;
    public articleList: any[];

    public isEffectBlock = false;
    public isEffectUser = false;
    public isEffectCoin = false;
    public isEffectMobile = false;

    public contactemail: string;

    constructor(private http: Http, @Inject(PLATFORM_ID) private platformId: Object, private blockService: BlockService, private lsService: LycStatService, private liService: LayoutInitService, public toastr: ToastsManager) {
        this.liServiceLocal = liService;

        this.liServiceLocal = liService;
        this.lcBlockService = blockService;
        this.lcLsService = lsService;

        this.currentBlock = Number(this.lcBlockService.getValue());
        this.currentMaxCoin = Number(this.lcLsService.getValue().coinTotal);
        this.currentMaxUserCount = Number(this.lcLsService.getValue().userTotal);

        this.subscription = this.lcBlockService.getMessage().subscribe(message => {
            this.message = message;
            this.currentBlock = Number(this.message.blockHead);
            this.currentBlockId = this.message.blockHeadId;
            this.currentLastWitness = this.message.lastWitness;
            this.isEffectBlock = true;

            let timeoutId = setTimeout(() => {
                this.isEffectBlock = false;
            }, 1000);

            if (this.currentLastMobileUser != this.message.lastMobileUser) {

                this.currentLastMobileUser = this.message.lastMobileUser;
                this.isEffectMobile = true;

                let timeoutId2 = setTimeout(() => {
                    this.isEffectMobile = false;
                }, 1000);
            }
        });

        this.subscriptionLycStat = this.lcLsService.getMessage().subscribe(message => {

            this.transactionList = message.lastEntries;

            let a1 = Number(message.coinTotal);
            let a2 = Number(message.userTotal);

            if (a1 != this.currentMaxCoin) {
                this.currentMaxCoin = a1;

                this.isEffectCoin = true;

                let timeoutId = setTimeout(() => {
                    this.isEffectCoin = false;
                }, 1000);
            }

            if (a2 != this.currentMaxUserCount) {
                this.currentMaxUserCount = a2;

                this.isEffectUser = true;

                let timeoutId2 = setTimeout(() => {
                    this.isEffectUser = false;
                }, 1000);
            }

        });

    }

    // google maps zoom level
    public zoom: number = 15;

    // initial center position for the map
    public lat: number = 47.176120;
    public lng: number = 8.500643;

    public transactionList: any[];

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInit();
            this.liServiceLocal.goToTop();

        }

    }

    public sendNewsletter() {
        
        if (this.contactemail) {

            let body = JSON.stringify({
                "contactEmail": this.contactemail
            });

            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            this.http.post("/api/sendNews", body, options)
                .subscribe(book => {
                    this.toastr.success("Message Sent !");
                },
                error => this.handleError);
        }
    }

    public handleError(error: Response) {
        this.toastr.error("Error occured !");
        return Observable.throw(error.json() || 'Server error');
    }

}