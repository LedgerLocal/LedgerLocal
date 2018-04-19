import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

@Injectable()
export class ContentService {
  
    private auth = new BehaviorSubject<any>(0);

    constructor(private http: HttpClient) {
    }

    public initContentList() {
    }

    public getAuthValue(): any {
      return this.auth.getValue();
    }

    public getAuth(): Observable<any> {
      return this.auth.asObservable();
    }

    public addAuth(a1: any): void {
      this.auth.next(a1);
    }

}
