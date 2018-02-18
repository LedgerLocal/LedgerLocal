import { PLATFORM_ID, Component, AfterViewInit, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LayoutInitService } from '../../service/layoutinit';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { AgmCoreModule } from '@agm/core';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'invest',
    templateUrl: './invest.component.html'
})
export class InvestComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;
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

    constructor(private http: Http, @Inject(PLATFORM_ID) private platformId: Object,
        private liService: LayoutInitService,
        public toastr: ToastsManager) {
        this.liServiceLocal = liService;

        this.liServiceLocal = liService;

        this.currentBlock = Number(0);
        this.currentMaxCoin = Number(0);
        this.currentMaxUserCount = Number(0);

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