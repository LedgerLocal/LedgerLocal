import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { HttpClientModule, HttpClient } from '@angular/common/http'

let counter = 0;

@Injectable()
export class UserService {

  private userArray: any[];

  constructor(private http: HttpClient) {
    // this.userArray = Object.values(this.users);
  }

  getContentBlockList() {
      return this.http.get<any>(
        '/v1/Contentblock/list'
      );
  }

  getUsers(): Observable<any> {
    return Observable.of(this.userArray);
  }

  getUserArray(): Observable<any[]> {
    return Observable.of(this.userArray);
  }

  getUser(): Observable<any> {
    counter = (counter + 1) % this.userArray.length;
    return Observable.of(this.userArray[counter]);
  }
}
