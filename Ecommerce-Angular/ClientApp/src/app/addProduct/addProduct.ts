import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { ToastService } from '../sevices/ToastService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'add-product',
  templateUrl: './addProduct.html',
})
export class AddProductComponent {
    baseUrl: string;
    

  constructor(private httpservice: EcommerceHttpService,
    private toast: ToastService,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private router: Router) {
    this.baseUrl = baseUrl;
    const productId = this.route.snapshot.paramMap.get('id');
    this.getProduct(productId);
  }

  product: any = {};
  uploadedProduct: File;

  addProducts(product, addProductForm) {
    this.httpservice.post('api/Product/AddProduct', product).subscribe(
      (data: any) => {
        addProductForm.reset();
        this.product.image = "";
        this.toast.sendMessage(data.message, 'alert-success');
        this.toast.closeAlert();
      },
      response => {
        this.toast.sendMessage(response.message, 'alert-danger');
        this.toast.closeAlert();
      });
  }

  updateProduct(product, addProductForm) {
    this.httpservice.post('api/Product/UpdateProduct', product).subscribe(
      (data: any) => {
        addProductForm.reset();
        this.product.image = "";
        this.toast.sendMessage(data.message, 'alert-success');
        this.toast.closeAlert();
        this.router.navigate(['/all-products/']); 
      },
      response => {
        this.toast.sendMessage(response.message, 'alert-danger');
        this.toast.closeAlert();
      });
  }

  getProduct(productId) {
    if (productId) {
      this.httpservice.get('api/Product/GetProduct/' + productId).subscribe(
        (data: any) => {
          this.product = data.value;
          this.product.image = this.baseUrl + this.product.image;
        },
        response => {

        });
    }
  }


  uploadProduct(file: FileList) {
    debugger;
    this.uploadedProduct = file.item(0);
    var myReader: FileReader = new FileReader();

    myReader.readAsDataURL(this.uploadedProduct);

    myReader.onloadend = (e) => {
      this.product.image = myReader.result;
    }

  }

}
