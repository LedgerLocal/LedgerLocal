import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subscription } from 'rxjs/Subscription';

@Injectable()
export class CoinService {

    private coinList: CoinRef[];
    private subject = new BehaviorSubject<CoinRef[]>([]);

    constructor(
        private http: HttpClient
    ) {

    }

    public initCoinList(token: any) {

        if (this.coinList && this.coinList.length > 0) {
            return;
        }

        if (token !== "") {
            let tokenValue = "Bearer " + token;

            let headers1 = new HttpHeaders()
                .set("Authorization", tokenValue);

            this.http.get<CoinRef[]>('https://api.loyaltycoin.ch/v1/coin/list', { headers: headers1 }).subscribe(data => {
                this.coinList = data;
                this.subject.next(this.coinList);
            });

        }


    }

    public getCoinList(): Observable<CoinRef[]> {
        return this.subject.asObservable();
    }

}

interface CoinRef {
    coinId: string;
    programId: string;
    programName: string;
    coinName: string;
    coinLabel: string;
    coinSymbol: string;
    createdOn: string;
    modifiedOn: string;
}
