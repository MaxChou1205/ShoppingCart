import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../../core/services/product.service';
import { OrderService } from '../../core/services/order.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent implements OnInit {

  baseData = [
    {
      id: 1,
      name: "Item-A",
      description: "lorem",
      price: 10,
      amount: 0
    },
    {
      id: 2,
      name: "Item-B",
      description: "ipsum",
      price: 20,
      amount: 0
    },
    {
      id: 3,
      name: "Item-C",
      description: "dolor",
      price: 30,
      amount: 0
    }
  ]

  items = [...this.baseData];

  totalPrice = 0;

  constructor(public http: HttpClient,
    private productService: ProductService,
    private orderService: OrderService) {

  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.productService.GetProducts().subscribe((products: any[]) => {
      products.map(product => product.amount = 0);
      this.items = [...products];
    });
  }

  addItem(id) {
    let item = this.items.find((item) => item.id == id);
    item.amount++;
    this.totalPrice += item.price;
  }

  removeItem(id) {
    let item = this.items.find((item) => item.id == id);
    if (item.amount > 0) {
      item.amount--;
      this.totalPrice -= item.price;
    }
  }

  checkout() {
    if (this.totalPrice > 0) {
      this.orderService.AddOrder(this.items).subscribe((result) => {
        if (result > 0) {
          alert("Order sent.");
          this.loadData();
          this.totalPrice = 0;
        }
      });
    }
    else {
      alert("Shopping cart is emty.");
    }
    //this.http.post('/api/Order/addOrder', this.items).subscribe(result => {
    //  alert("Order Sent.");
    //  this.items = [...this.baseData];
    //}, error => console.error(error));
  }
}
