import { Component, OnInit } from '@angular/core';
import { ToastService } from '../sevices/ToastService';


@Component({
    selector: 'toast-message',
    templateUrl: './toaster.html',
    styles: [`.notification{
               width: 300px;
               position: absolute;
               top: -10px;
               right: -20;
               z - index: 10000;
             }`]
})
export class ToastMessageComponent implements OnInit {

    message: any;
    isSuccess: any;

    constructor(private toast: ToastService) { }

    ngOnInit(): void {
        this.toast.sendMessage('', '');
        this.toast.cast.subscribe(message => this.message = message);
    }

    closeAlert() {
        this.toast.sendMessage('', '');
  } 
}
