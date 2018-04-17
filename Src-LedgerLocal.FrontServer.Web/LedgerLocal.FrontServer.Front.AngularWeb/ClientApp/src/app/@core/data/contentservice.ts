import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

@Injectable()
export class ContentService {

    private contentList: any;
    private subject = new BehaviorSubject<any>([]);
    private auth = new BehaviorSubject<any>(0);

    constructor(private http: HttpClient) {
    }

    public initContentList() {

      if (this.contentList && this.contentList.length > 0) {
            return;
      }

    }

    public getContentList(): Observable<any> {
      return this.subject.asObservable();
    }

    public getAuth(): Observable<any> {
      return this.auth.asObservable();
    }

    public addAuth(a1: any): void {
      this.auth.next(a1);
    }

}
