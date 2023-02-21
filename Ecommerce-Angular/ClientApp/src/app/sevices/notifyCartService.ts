import { Injectable } from "@angular/core";

@Injectable()
export class NotifyCartService {
  private items: any[] = [];
  private actions = [];


  add(func: (param) => void) {
    this.actions.push(func);
  }

  execute() {
    for (var action of this.actions) {
      action();
    }
  }

  addItem(product) {
    let _product = this.items.find(x => x.id == product.id);
    if (_product) {
      debugger;
      let index = this.items.indexOf(_product);
      this.items.splice(index,1);
    }
    this.items.push(product);
  }

  getItems() {
    return this.items;
  }

  //removeItem(item) {
  //  var index = this.items.indexOf(item);
  //  this.items.splice(index, 1);
  //}
}
