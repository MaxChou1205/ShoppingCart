import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  baseData = [
    {
      id: 1,
      name: "Item-A",
      description: "lorem",
      price: 10,
      amount: 50
    },
    {
      id: 2,
      name: "Item-B",
      description: "ipsum",
      price: 20,
      amount: 10
    },
    {
      id: 3,
      name: "Item-C",
      description: "dolor",
      price: 30,
      amount: 20
    }
  ]

  items = [...this.baseData];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    //this.http.get(this.baseUrl + '/Order/getOrders').subscribe((result: any) => {
    //  this.items = result.Data;
    //}, error => console.error(error));
  }

  ngOnInit() {
  }

}
