import { Component, ViewContainerRef, OnInit, OnDestroy, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { OnlineService } from '../../service/onlineservice';
import { LayoutInitService } from '../../service/layoutinit';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy, AfterViewInit {
    private lcOnlineService: OnlineService;
    private liServiceLocal: LayoutInitService;
    
    public contactname: string;
    public contactemail: string;
    public contactphone: string;
    public contactsubject: string;
    public contactbody: string;
    //public contactservice: string;

    public lat: number = 47.166156;
    public lng: number = 8.515933;

    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean;

    isLoaded: boolean;

    constructor(private http: Http, @Inject(PLATFORM_ID) private platformId: Object, private liService: LayoutInitService,
        private onlineService: OnlineService,
        public toastr: ToastsManager, vRef: ViewContainerRef, public oidcSecurityService: OidcSecurityService) {

        this.isLoaded = false;
        this.liServiceLocal = liService;
        this.lcOnlineService = onlineService;

        this.toastr.setRootViewContainerRef(vRef);

        if (this.oidcSecurityService.moduleSetup) {
            this.doCallbackLogicIfRequired();
        } else {
            this.oidcSecurityService.onModuleSetup.subscribe(() => {
                this.doCallbackLogicIfRequired();
            });
        }
        
    }

    public sendContactInfo() {
        if (this.contactemail) {

            let body = JSON.stringify({
                "contactName": this.contactname,
                "contactEmail": this.contactemail,
                "contactPhone": this.contactphone,
                "contactSubject": this.contactsubject,
                "contactBody": this.contactbody,
            //    "contactService": this.contactservice
            });
            
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            this.http.post("/api/sendContact", body, options)
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

    public isInBrowser() {
        return isPlatformBrowser(this.platformId);
    }

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            setTimeout(function () {

                var jQuery = require("jquery");
                var $ = jQuery as any;
                var $target = $('.loadinginit');

                $target.hide('slow', function () { $target.remove(); });
                
            }, 3000);
            
        }

    }

    ngOnInit() {

        if (isPlatformBrowser(this.platformId)) {
            
        }

        this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
            });
        
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();
        this.oidcSecurityService.onModuleSetup.unsubscribe();
    }

    public login() {
        this.oidcSecurityService.authorize();
    }

    public logout() {
        this.oidcSecurityService.logoff();
    }

    private doCallbackLogicIfRequired() {

        if (isPlatformBrowser(this.platformId)) {

            if (window.location.hash) {
                this.oidcSecurityService.authorizedCallback();
            }

        }
        
    }

}
