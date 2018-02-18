import { PLATFORM_ID, Component, AfterViewInit, Inject, OnInit, OnDestroy } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Subscription } from 'rxjs/Subscription';
import { LayoutInitService } from '../../service/layoutinit';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
    selector: 'userprofil',
    templateUrl: './userprofil.component.html'
})
export class UserProfilComponent implements AfterViewInit, OnInit, OnDestroy {

    private liServiceLocal: LayoutInitService;
    public currentCount = 0;
    message: any;
    isAuthorizedSubscription: Subscription;
    isAuthorized: boolean;
    userDataSubscription: Subscription;
    public userData: any;
    public userName: string;
    token: string;
    public imgQrCode: string;

    public userProfilData: any;
    public userPhoneData: any;
    public imgProfile: string;

    constructor( @Inject(PLATFORM_ID) private platformId: Object,
        private liService: LayoutInitService,
        private oidcSecurityService: OidcSecurityService,
        public toastr: ToastsManager,
        private http: HttpClient) {

        this.liServiceLocal = liService;

        this.userProfilData = {};
        this.userPhoneData = {};

    }

    ngAfterViewInit() {

        if (isPlatformBrowser(this.platformId)) {

            this.liServiceLocal.makeInit();
            this.liServiceLocal.goToTop();

        }

    }

    ngOnInit() {
        this.isAuthorizedSubscription = this.oidcSecurityService.getIsAuthorized().subscribe(
            (isAuthorized: boolean) => {
                this.isAuthorized = isAuthorized;
                if (this.isAuthorized) {

                    this.token = this.oidcSecurityService.getToken();

                    this.userDataSubscription = this.oidcSecurityService.getUserData().subscribe(
                        (userData: any) => {

                            this.userData = userData;

                            if (this.userData && this.userData.customerid) {

                                this.userName = this.userData.name;

                                if (this.token !== "") {
                                    let tokenValue = "Bearer " + this.token;

                                    let headers1 = new HttpHeaders()
                                        .set("Authorization", tokenValue);

                                    this.http.get<CustomerInfoEncap>('https://api.loyaltycoin.ch/v1/customer/byId?id=' + this.userData.customerid,
                                        { headers: headers1 }).subscribe(data => {

                                            this.userProfilData = data;

                                            if (data && data.postalAddress) {

                                                this.userPhoneData = data.postalAddress;

                                            }

                                            if (data && data.picture) {
                                                this.imgProfile = 'data:image/png;base64,' + data.picture;
                                            }

                                            this.toastr.success("User Profil Loaded !");
                                        });

                                }

                            }

                        });
                }
            });

    }

    ngOnDestroy(): void {
        this.isAuthorizedSubscription.unsubscribe();

        if (this.userDataSubscription) {
            this.userDataSubscription.unsubscribe();
        }
    }

}

interface CustomerInfoEncap {
    customerId: string;
    salutation: string;
    firstlogin: string;
    lastlogin: string;
    registrationDate: string;
    firstName: string;
    lastName: string;
    phone: string;
    email: string;
    postalAddress: CustomerPostalEncap;
    picture: string;
    active: boolean;
    birthDate: string;
    mobileLanguage: string;
}

interface CustomerPostalEncap {
    entityName: string;
    streetName: string;
    streetNumber: string;
    zipCode: string;
    city: string;
    state: string;
    country: string;
}

//{
//    "customerId": "23",
//        "salutation": "Male",
//            "firstlogin": null,
//                "lastlogin": null,
//                    "registrationDate": null,
//                        "firstName": "Alexandre",
//                            "lastName": "Lazar",
//                                "phone": "7654321",
//                                    "email": "alexandre.lazar@gmail.com",
//                                        "wallet": null,
//                                            "postalAddress": {
//        "entityName": null,
//            "streetName": "Birmensdorferstrasse 188",
//                "streetNumber": "Birmensdorferstrasse 188",
//                    "zipCode": "8003",
//                        "city": "Zurich",
//                            "state": "Zurich",
//                                "country": "Switzerland "
//    },
//    "picture": "",
//        "active": null,
//            "birthDate": "1983-02-03T00:00:00",
//                "mobileLanguage": "en"
//}