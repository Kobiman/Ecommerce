import { Component } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  products: any = [];

  constructor(private httpservice: EcommerceHttpService) {

  }

}
