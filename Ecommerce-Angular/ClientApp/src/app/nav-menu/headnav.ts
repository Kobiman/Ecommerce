import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { NotifyCartService } from '../sevices/notifyCartService';

@Component({
  selector: 'head-menu',
  templateUrl: './headnav.html',
  //styleUrls: ['./nav-menu.component.css']
})
export class HeadNavComponent {
  products: any[] = [];

  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router, private notifyCartService: NotifyCartService) {
    //this.baseUrl = baseUrl;
    //const productId = this.route.snapshot.paramMap.get('id');
    //this.getProduct(productId);
    this.notifyCartService.add(() => {
       this.products = this.notifyCartService.getItems();
    });
  }
}
