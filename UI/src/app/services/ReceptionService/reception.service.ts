import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagedResult } from "../../common/order-registry";
import { OrderRegistryItem } from "../../domain/registry/order-registry-item";
import { Observable } from 'rxjs';

import { ReceptionRegistryRequest } from "./reception-registry-request";
import { Order } from '../../domain/order/order';
import { urls } from 'src/main';

@Injectable()
export class ReceptionService {

  constructor(private http: HttpClient) { }

  public getByFilter(request: ReceptionRegistryRequest) : Promise<PagedResult<OrderRegistryItem>>{
    return this.http.post<PagedResult<OrderRegistryItem>>(urls.OrderRegistryApiUrl, request).toPromise();
  }

  get(id: number): Observable<Order>{
    return this.http.get<Order>(urls.OrderApiUrl+id);
  }
}
