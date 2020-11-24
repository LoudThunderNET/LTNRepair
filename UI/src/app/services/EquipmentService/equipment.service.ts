import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Equipment } from '../../domain/equipment';
import { EquipmentRequest } from "../EquipmentService/equipment-request";
import { environment } from 'src/environments/environment';

@Injectable()
export class EquipmentService {
  private equipmentApiUrl:string;

  constructor(private http: HttpClient) { 
    this.equipmentApiUrl = environment.apiBaseUrl+'Equipment/';
  }

  get(id: number): Observable<Equipment>{
    return this.http.get<Equipment>(this.equipmentApiUrl+id);
  }

  getByFilter(request:EquipmentRequest): Observable<Equipment[]>{
    return this.http.post<Equipment[]>(this.equipmentApiUrl+'filtered', request);
  }
}
