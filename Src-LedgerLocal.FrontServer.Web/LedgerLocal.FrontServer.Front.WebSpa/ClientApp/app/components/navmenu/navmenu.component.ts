import { PLATFORM_ID, Component, AfterViewInit, Inject, OnInit, OnDestroy } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Subscription } from 'rxjs/Subscription';
import { OnlineService } from '../../service/onlineservice';
import { LayoutInitService } from '../../service/layoutinit';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html'
})
export class NavMenuComponent implements AfterViewInit, OnInit, OnDestroy {

    private liServiceLocal: LayoutInitService;
    private lcOnlineService: OnlineService;
    public currentCount = 0;
    public labelLoggin = 'Login';
    message: any;
    subscription: Subscription;
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean;
    userDataSubscription: Subscription;
    public userData: any;
    public userName: string;
    token: string;
    public imgQrCode: string;

    constructor( @Inject(PLATFORM_ID) private platformId: Object,
        private onlineService: OnlineService,
        private liService: LayoutInitService,
        private oidcSecurityService: OidcSecurityService,
        public toastr: ToastsManager,
        private http: HttpClient) {

        this.lcOnlineService = onlineService;
        this.liServiceLocal = liService;

        this.subscription = this.lcOnlineService.getMessage().subscribe(message => {
            this.message = message;
            this.currentCount = Number(this.message.onlineUser);
        });

    }
    
    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInitHeader();

        }

    }

    ngOnInit() {
        this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
                if (this.isAuthorized) {

                    this.token = this.oidcSecurityService.getToken();
                    this.toastr.success("Authorized !");
                    
                    this.userDataSubscription = this.oidcSecurityService.getUserData().subscribe(
                        (userData: any) => {

                            this.userData = userData;

                            if (this.userData && this.userData.customerid) {

                                this.userName = this.userData.name;

                                if (this.userName) {

                                    this.labelLoggin = this.userName.split('@')[0];

                                }
                                
                                if (this.token !== "") {
                                    let tokenValue = "Bearer " + this.token;

                                    let headers1 = new HttpHeaders()
                                        .set("Authorization", tokenValue);

                                    this.http.get<QrCodeEncap>('/api/customer/getQrCodeForCustomer?customerId=' + this.userData.customerid + '&width=500&height=500&margin=10',
                                        { headers: headers1 }).subscribe(data => {

                                            if (data && data.imagePng) {

                                                this.imgQrCode = data.imagePng;

                                                this.toastr.success("QrCode Loaded !");

                                            }
                                            
                                        });

                                }

                            }

                        });
                }
            });


        //console.log('IsAuthorized:' + this.isAuthorized);
    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();

        if (this.userDataSubscription) {
            this.userDataSubscription.unsubscribe();
        }
    }

    public login() {
        this.oidcSecurityService.authorize();
    }

}

interface QrCodeEncap {
    imagePng: string;
}