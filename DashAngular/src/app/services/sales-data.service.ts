import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class SalesDataService {

  constructor(public _http: HttpClient) { }

  getOrders(pageIndex: number, pageSize: number) {
    return this._http.get('http://localhost:62781/api/order/' + pageIndex + '/' + pageSize)
    }

  getOrdersByCustomer(n: number) {
    return this._http.get('http://localhost:62781/api/order/bycustomer/' + n);
  }

  getOrdersByState() {
    return this._http.get('http://localhost:62781/api/order/bystate/');
  }
}