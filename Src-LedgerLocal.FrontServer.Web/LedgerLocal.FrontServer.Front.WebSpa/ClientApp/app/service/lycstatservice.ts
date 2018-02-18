import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class LycStatService {

    private subject = new BehaviorSubject<any>(0);
	
    sendMessage(userNum: Number, coinNum: Number, entries: any[]) {
        this.subject.next({ userTotal: userNum, coinTotal: coinNum, lastEntries: entries });
    }

    clearMessage() {
        //this.subject.next();
    }

    getMessage(): Observable<any> {
        return this.subject.asObservable();
    }

    getValue(): any {
        return this.subject.getValue();
    }

}