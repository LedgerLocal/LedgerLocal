import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http'

@Injectable()
export class SmartTableService {

  constructor(private http: HttpClient) {
  }

  getAvailableCrypto() {
    return this.http.get<any>(
      'https://www.ledgerlocal.com:5544/v1/participate/cryptoPaymentAvailable'
    );
  }

  initiateTrade(inputCoin: string, amount: Number) {
    return this.http.get<any>(
      'https://www.ledgerlocal.com:5544/v1/participate/initiateTrade?inputCoin=' + inputCoin + '&amount=' + amount
    );
  }

}
