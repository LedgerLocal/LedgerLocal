import { PLATFORM_ID, Component, AfterViewInit, Inject, OnInit, OnDestroy } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LayoutInitService } from '../../service/layoutinit';
import { CoinService } from '../../service/coinservice';
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
        private http: HttpClient,
        private coinService: CoinService) {

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
                    this.coinService.initCoinList(this.token);
                    
                    this.userDataSubscription = this.oidcSecurityService.getUserData().subscribe(
                        (userData: any) => {
                            this.userData = userData;

                            this.userMail = this.userData.name;

                            this.coinListSubscription = this.coinService.getCoinList().subscribe(message => {

                                if (this.userData && this.userData.customerid && message && message.length > 0) {
                                    this.coinList = message;

                                    this.refreshWallet();
   
                                }
                                
                            });
                            
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
            let tokenValue = "Bearer " + this.token;

            let headers1 = new HttpHeaders()
                .set("Authorization", tokenValue);

            this.http.get<UserWallet[]>('https://api.loyaltycoin.ch/v1/point/balance?customerId=' + this.userData.customerid,
                { headers: headers1 }).subscribe(data => {
                    this.userWallets = data;

                    for (let uw1 of this.userWallets) {

                        var cFound = this.getCoinItem(uw1.coinId, this.coinList);
                        uw1.coinLabel = cFound.coinSymbol;
                        uw1.programName = cFound.programName;
                        uw1.isJoined = true;

                        var h1 = _.orderBy(uw1.history, ['pointBalanceEntryId'], ['desc']);
                        uw1.history = _.take(h1, 10);
                    }

                    if (this.userWallets.length != this.coinList.length) {

                        if (!this.userWallets || this.userWallets.length == 0) {

                            this.userWallets = [];

                        }

                        var mapCoinList = _.map(this.coinList, 'coinId');
                        var mapWalletList = _.map(this.userWallets, 'coinId');

                        var a1 = _.difference(mapCoinList, mapWalletList);

                        for (let cn1 of a1) {

                            var coinFound = this.getCoinItem(cn1, this.coinList);

                            var uw1 = {
                                pointBalanceProgramId: "0",
                                customerId: "0",
                                coinId: coinFound.coinId,
                                coinLabel: coinFound.coinSymbol,
                                programName: coinFound.programName,
                                balanceAvailable: Number(0),
                                creditAmount: Number(0),
                                debitAmount: Number(0),
                                history: [],
                                activate: true,
                                isJoined: false,
                                createdOn: "",
                                modifiedOn: ""
                            };

                            this.userWallets.push(uw1);
                        }
                    }

                    this.toastr.success("User Wallet Loaded !");
                });

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