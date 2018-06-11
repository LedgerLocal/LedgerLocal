import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class OnlineService {

    private subject = new BehaviorSubject<any>(0);
	
    sendMessage(onlineNum: Number) {
        this.subject.next({ onlineUser: onlineNum });
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
