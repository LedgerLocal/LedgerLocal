import { Component, ViewContainerRef, OnInit, OnDestroy, AfterViewInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { OnlineService } from '../../service/onlineservice';
import { BlockService } from '../../service/blockservice';
import { LycStatService } from '../../service/lycstatservice';
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
    private lcBlockService: BlockService;
    private lcLsService: LycStatService;
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
        private blockService: BlockService, private lsService: LycStatService,
        public toastr: ToastsManager, vRef: ViewContainerRef, public oidcSecurityService: OidcSecurityService) {

        this.isLoaded = false;
        this.liServiceLocal = liService;
        this.lcOnlineService = onlineService;
        this.lcBlockService = blockService;
        this.lcLsService = lsService;

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
            
            var signalR = require("../../../../scripts/signalr-clientES5-1.0.0-alpha2-final.js");

            let connection = new signalR.HubConnection('/rtlyc');

            connection.on('online', data => {

                this.lcOnlineService.sendMessage(Number(data));

            });

            connection.on('blockNumberRefresh', data => {
                //InvokeAsync("blockNumberRefresh",  new { HeadBlockNumber = fO1.HeadBlockNumber, HeadBlockId = idLadtBlock, CurrentWitness = fO1.CurrentWitness, LastActiveMobile = numLastMobileUSer });
                this.lcBlockService.sendMessage(Number(data.headBlockNumber), data.headBlockId, data.currentWitness, Number(data.lastActiveMobile));
            });

            connection.on('lycStatRefresh', data => {

                this.lcLsService.sendMessage(Number(data.totalUsers), Number(data.allPoints), data.lastCoinLedgerList);

            });

            connection.start();
            //.then(() => connection.invoke('send', 'Hello'));


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
