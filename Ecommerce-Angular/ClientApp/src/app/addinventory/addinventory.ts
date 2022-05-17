import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../sevices/ToastService';

@Component({
  selector: 'add-new-inventory',
  templateUrl: './addinventory.html',
})
export class addInventoryComponent {
    product: any = {};
    baseUrl: string;
    products: any;
    inventory: any = {};

  constructor(private httpservice: EcommerceHttpService,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private toast: ToastService,
    private router: Router) {
    this.baseUrl = baseUrl; 
    
   this.getProducts();
}

  getProducts() {
    this.httpservice.get('api/Product/GetProducts').subscribe(
      (data: any) => {
        this.products = data.value;
        for (const product of this.products) {
          product.image = this.baseUrl + product.image;
        }
      },
      response => {

      });
  }

  addInventory(inventory, addinventoryform) {
    inventory.unitPrice = this.product.price;
    inventory.productId = this.product.productId;
    this.httpservice.post('api/ProductTransaction/AddProductTransaction', inventory).subscribe(
      (data: any) => {
        addinventoryform.reset();
        this.product = {};
        this.inventory = {};
        this.toast.sendMessage(data.message, 'alert-success');
        this.toast.closeAlert();
      },
      response => {
        this.toast.sendMessage(response.message, 'alert-danger');
        this.toast.closeAlert();
      });
  }

  calculateTotalAmount(price, quantity) {
    this.inventory.totalAmount = price * quantity;
  }

}
