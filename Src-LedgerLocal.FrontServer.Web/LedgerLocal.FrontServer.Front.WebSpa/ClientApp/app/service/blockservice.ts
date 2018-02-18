import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class BlockService {

    private subject = new BehaviorSubject<any>(0);
	
    sendMessage(blockNum: Number, pblockHeadId: string, plastWitness: string, plastMobileUser: Number) {
        this.subject.next({ blockHead: blockNum, blockHeadId: pblockHeadId, lastWitness: plastWitness, lastMobileUser: plastMobileUser });
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