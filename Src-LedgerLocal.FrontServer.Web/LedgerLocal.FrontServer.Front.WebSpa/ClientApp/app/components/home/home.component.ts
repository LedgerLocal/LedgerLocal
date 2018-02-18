import { PLATFORM_ID, Component, AfterViewInit, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { Subscription } from 'rxjs/Subscription';
import { LayoutInitService } from '../../service/layoutinit';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';



@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;

    public message: any;
    public subscription: Subscription;
    public subscriptionLycStat: Subscription;
    public articleList: any[];

    public contactemail: string;

    // google maps zoom level
    public zoom: number = 15;

    // initial center position for the map
    public lat: number = 47.176120;
    public lng: number = 8.500643;

    public transactionList: any[];

    constructor(private http: Http, 
	    @Inject(PLATFORM_ID) private platformId: Object,
        private liService: LayoutInitService, 
        public toastr: ToastsManager) {

        this.liServiceLocal = liService;
    }

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

    public login() {
                        
    }

    public handleError(error: Response) {
        this.toastr.error("Error occured !");
        return Observable.throw(error.json() || 'Server error');
    }

}
