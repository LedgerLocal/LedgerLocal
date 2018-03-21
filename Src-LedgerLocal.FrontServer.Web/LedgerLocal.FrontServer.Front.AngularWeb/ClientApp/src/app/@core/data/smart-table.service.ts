import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http'

@Injectable()
export class SmartTableService {

  constructor(private http: HttpClient) {
  }

  data = [{
    id: 1,
    firstName: 'Mark',
    lastName: 'Otto',
    username: '@mdo',
    email: 'mdo@gmail.com',
    age: '28',
  }, {
    id: 2,
    firstName: 'Jacob',
    lastName: 'Thornton',
    username: '@fat',
    email: 'fat@yandex.ru',
    age: '45',
  }];

  getData() {
    return this.data;
  }

  getCurrentMiningHostListZeroHash() {
    return this.http.get<any>(
      '/v1/miner/currentMiningHostListZeroHash'
    );
  }

  getCurrentMiningHostListHash() {
    return this.http.get<any>(
      '/v1/miner/currentMiningHostListHash'
    );
  }

  getStatFromMinerHost(hostname: string) {
    return this.http.get<any>(
      '/v1/miner/hashRatePerHourByHostnameLastDay?hostname=' + hostname
    );
  }

  getGlobalStats(startDate: string, endDate: string) {
    return this.http.get<any>(
      '/v1/miner/globalHashRatePerHour?startDate=' + startDate + '&endDate=' + endDate
    );
  }

  getCurrentActive() {
    return this.http.get<any>(
      '/v1/miner/currentActive'
    );
  }

  getRealHashingPower() {
    return this.http.get<any>(
      '/v1/miner/currentRealHashingPower'
    );
  }

  getAverageHashingPower() {
    return this.http.get<any>(
      '/v1/miner/currentAverageHashingPower'
    );
  }

  getCurrentInactive() {
    return this.http.get<any>(
      '/v1/miner/currentInactive'
    );
  }





  /* =================================================================== */

  getDetailHashRate(hostname:string, startDate: string, endDate: string) {
    return this.http.get<any>(
      '/v1/minerdetail/hashRateByHostname?hostname=' + hostname + '&startDate=' + startDate + '&endDate=' + endDate
    );
  }

  getDetailTemperatureOne(hostname: string, startDate: string, endDate: string) {
    return this.http.get<any>(
      '/v1/minerdetail/temperatureOneByHostname?hostname=' + hostname + '&startDate=' + startDate + '&endDate=' + endDate
    );
  }

  getDetailTemperatureTwo(hostname: string, startDate: string, endDate: string) {
    return this.http.get<any>(
      '/v1/minerdetail/temperatureTwoByHostname?hostname=' + hostname + '&startDate=' + startDate + '&endDate=' + endDate
    );
  }

  getDetailFanRate(hostname: string, startDate: string, endDate: string) {
    return this.http.get<any>(
      '/v1/minerdetail/fanRateByHostname?hostname=' + hostname + '&startDate=' + startDate + '&endDate=' + endDate
    );
  }

}
