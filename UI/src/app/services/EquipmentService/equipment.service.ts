import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from 'rxjs';
import { Equipment } from '../../domain/order/equipment';
import { EquipmentRequest } from "../EquipmentService/equipment-request";

@Injectable()
export class EquipmentService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<Equipment>{
    const result = new BehaviorSubject<Equipment>(null);
    result.next(EquipmentService.equipments.find((element, index)=> element.id === id));

    return result.asObservable();
  }

  getByFilter(request:EquipmentRequest): Observable<Equipment[]>{
    const result:Equipment[] = [];
    for(let index = 0; index < EquipmentService.equipments.length; index++){
      let matchedByNode:boolean = true;
      let matchedByParentId:boolean = true;
      let matchedByName:boolean = true;

      const equipment = EquipmentService.equipments[index];

      if(request){
        if(request.node !== null)
        {
          matchedByNode = equipment.isNode === request.node;
        }
        if(request.name)
        {
          matchedByName = equipment.name.toLowerCase().startsWith(request.name.toLowerCase());
        }
        if(request.parentIds){
          matchedByParentId = request.parentIds.findIndex((v, i, a)=> v === equipment.parentId) !== -1;
        }
      }

      if(matchedByNode && matchedByParentId && matchedByName){
        result.push(EquipmentService.equipments[index]);
      }
    }

    return new BehaviorSubject<Equipment[]>(result).asObservable();
  }

  static equipments: Equipment[] = [
    new Equipment(1, 'Ноутбуки', true, null, ['ноутбук','блок питания','силовой кабель']),
      new Equipment(4, 'Asus', true, 1, null),
        new Equipment(13, 'Asus F35', false, 4, null),
        new Equipment(14, 'Asus X55', false, 4, null),
    new Equipment(5, 'Acer', true, 1, null),
        new Equipment(15, 'Acer Aspire 5320', false, 5, null),
        new Equipment(16, 'Acer Aspire 3 A351', false, 5, null),
        new Equipment(17, 'Acer Aspire 7 A784', false, 5, null),
    new Equipment(6, 'Lenovo', true, 1, null),
      new Equipment(18, 'Lenovo Ideapad V17', false, 6, null),
      new Equipment(19, 'Lenovo Ideapad G530', false, 6, null),
    new Equipment(2, 'Планшеты', true, null, ['планшет','блок питания','силовой кабель']),
      new Equipment(7, 'Huawei MatePad Pro', false, 2, null),
      new Equipment(8, 'Lenovo Tab M10 HD', false, 2, null),
      new Equipment(9, 'Apple iPad 3', false, 2, null),
    new Equipment(3, 'Бытовая техника', true, null, null),
      new Equipment(10, 'Холодильники', true, 3, ['холодильник','полки','держатели продукты']),
        new Equipment(7, 'Стинол 355', false, 10, null),
      new Equipment(11, 'Стириальные машины', true, 3, ['сма','кювета','контейнер']),
        new Equipment(7, 'Zanussi ZWY50924CI', false, 11, null),
      new Equipment(12, 'Утюги', true, 3, ['утюг','кювета']),
        new Equipment(7, 'Philips Azur GC4560', false, 12, null),
  ];
}
