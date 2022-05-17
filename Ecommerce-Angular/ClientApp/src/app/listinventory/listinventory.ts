import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../sevices/ToastService';

@Component({
  selector: 'all-inventory',
  templateUrl: './listinventory.html',
})
export class listinventoryComponent {
  inventorys: any = [];
  baseUrl: any;
  finished = false;

  constructor(private httpservice: EcommerceHttpService,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private toast: ToastService,
    private router: Router) {
    this.baseUrl = baseUrl; 
    
   this.getInventorys();
}

  getInventorys() {
    this.httpservice.get('api/Product/GetProductsInventory').subscribe(
      (data: any) => {
        this.inventorys = data.value;
        for (const inventory of this.inventorys) {
          inventory.image = this.baseUrl + inventory.image;
          if (inventory.description.length > 50) {
            inventory.description = inventory.description.substring(0, 50) + "...";
          }
        }
      },
      response => {

      });
  }

  //onScroll() {
  //  if (this.finished === false) {
  //    this.httpservice.get(`api/Product/GetProducts/${this.inventorys.length}/20`).subscribe(
  //      (data: any) => {
  //        if (data.value.length === 0) { this.finished = true }
  //        for (const inventory of data.value) {
  //          inventory.image = this.baseUrl + inventory.image;
  //          if (inventory.description.length > 50) {
  //            inventory.description = inventory.description.substring(0, 50) + "...";
  //          }
  //          this.inventorys.push(inventory);
  //        }
  //      },
  //      response => {

  //      });
  //  }
  //}

  editInventory(inventoryId) {
    this.router.navigate(['/add-new-inventory/', inventoryId]);      
  }

}
