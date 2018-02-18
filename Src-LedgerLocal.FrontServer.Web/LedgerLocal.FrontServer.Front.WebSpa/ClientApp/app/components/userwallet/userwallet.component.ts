import { PLATFORM_ID, Component, AfterViewInit, Inject, OnInit, OnDestroy } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LayoutInitService } from '../../service/layoutinit';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';
import * as _ from "lodash";

@Component({
    selector: 'userwallet',
    templateUrl: './userwallet.component.html'
})
export class UserWalletComponent implements AfterViewInit {

    private liServiceLocal: LayoutInitService;
    subscription: Subscription;
    isAuthorizedSubscription: Subscription;
    coinListSubscription: Subscription;
    isAuthorized: boolean;
    userDataSubscription: Subscription;
    public userData: any;
    public userWallets: UserWallet[];
    public coinList: any[];
    public userMail: string;
    private token: any;

    constructor( @Inject(PLATFORM_ID) private platformId: Object,
        private liService: LayoutInitService,
        private oidcSecurityService: OidcSecurityService,
        public toastr: ToastsManager,
        private http: HttpClient) {

        this.liServiceLocal = liService;

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

                            this.userMail = this.userData.name;

                            
                        });

                }
            });
        
    }

    public joinProgram(programId: string) {
        if (this.token !== "") {
            let tokenValue = "Bearer " + this.token;

            let headers1 = new HttpHeaders()
                .set("Authorization", tokenValue);

            this.http.get<UserWallet[]>('https://api.loyaltycoin.ch/v1/program/addCustomer?programId=' + programId + '&customerId=' + this.userData.customerid,
                { headers: headers1 }).subscribe(data => {
                   
                    this.toastr.success("Program joined !");
                    this.refreshWallet();
                });
        }
    }

    private refreshWallet() {

        if (this.token !== "") {
           

        }

    }

    private getCoinItem(coinId: string, coinList: any[]): any {
        for (let c1 of this.coinList) {

            if (c1.coinId == coinId) {
                return c1;
            }

        }
        return {};
    }

    ngOnDestroy(): void {

        this.isAuthorizedSubscription.unsubscribe();

        if (this.userDataSubscription) {
            this.userDataSubscription.unsubscribe();
        }

    }

}

interface UserWallet {
    pointBalanceProgramId: string;
    customerId: string;
    coinId: string;
    coinLabel: string;
    programName: string;
    balanceAvailable: Number;
    creditAmount: Number;
    debitAmount: Number;
    history: UserWalletEntry[];
    createdOn: string;
    modifiedOn: string;
    activate: boolean;
    isJoined: boolean;
}

interface UserWalletEntry {
    pointBalanceEntryId: string;
    credit: Number;
    debit: Number;
    createdOn: string;
    activate: boolean;
}