import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/Product';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  products: IProduct[] =[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<IProduct[]>("https://localhost:7168/product").subscribe(p => {
      this.products = p;
    });
  }
}
