import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css']
})
export class HomeComponent {

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

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    
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
    this.http.post(this.baseUrl + '/Order/addOrder', this.items).subscribe(result => {
      alert("Order Sent.");
      this.items = [...this.baseData];
    }, error => console.error(error));
  }
}
