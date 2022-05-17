import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export class Message {
    content: string;
    style: string;
    dismissed = false;

    constructor(content: string, style: string) {
        this.content = content;
        this.style = style;
    }
}


@Injectable()
export class ToastService {

    private message = new BehaviorSubject<Message>(new Message('', ''));
    cast = this.message.asObservable();

    constructor() { }

    sendMessage(content: string, style: string) {
        this.message.next(new Message(content, style));
    }


    closeAlert() {
        setTimeout(() => { this.sendMessage('', ''); }, 5000);
    }
}
