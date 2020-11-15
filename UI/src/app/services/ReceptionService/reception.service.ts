import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PagedResult } from "../../common/order-registry";
import { OrderRegistryItem } from "../../domain/registry/order-registry-item";
import { Observable } from 'rxjs';

import { ReceptionRegistryRequest } from "./reception-registry-request";
import { Order } from '../../domain/order/order';
import { environment } from 'src/environments/environment';

@Injectable()
export class ReceptionService {

  constructor(private http: HttpClient) { }

  public getByFilter(request: ReceptionRegistryRequest) : Promise<PagedResult<OrderRegistryItem>>{
    return this.http.post<PagedResult<OrderRegistryItem>>(environment.apiBaseUrl+'OrderRegistry', request).toPromise();
  }

  get(id: number): Observable<Order>{
    return this.http.get<Order>(environment.apiBaseUrl+'Order/'+id);
  }
}
