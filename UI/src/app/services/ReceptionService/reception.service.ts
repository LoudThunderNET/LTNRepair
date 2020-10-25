import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderRegistry } from "../../domain/registry/order-registry";
import { OrderRegistryItem } from "../../domain/registry/order-registry-item";
import { ClientTypeEnum } from "../../domain/enums/client-type-enum.enum";
import { OrderItemStatusEnum } from '../../domain/enums/order-item-status-enum.enum';
import { ReceptionRegistryRequest } from "./reception-registry-request";
import { BehaviorSubject, Observable } from 'rxjs';
import { Order } from '../../domain/order/order';
import { JuridicalPerson } from '../../domain/order/juridical-person';
import { PhysicalPerson } from '../../domain/order/physical-person';
import { Client } from 'src/app/domain/client';
import {ClientService} from 'src/app/services/ClientService/client.service';

@Injectable()
export class ReceptionService {
  private static items : OrderRegistryItem[]  = [
    {
      id:1,
      creationDate:new Date(2020, 9, 1),
      client: ClientService.clients[0],
      status: OrderItemStatusEnum.Diagnostics,
      equipment:{
        id:1,
        name:'Холодильник Стинол 352'
      },
      defectDescription:'не включается',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'холодильник, коробка, полки, подон, держатели продуктов (6 штук)',
      parts:[],
      repairCost:null
    },
    {
      id:2,
      creationDate:new Date(2020, 9, 1),
      client:ClientService.clients[1],
      status: OrderItemStatusEnum.DiagnosticsCompleted,
      equipment:{
        id:2,
        name:'Магнитола philips RMP-522'
      },
      defectDescription:'слышен гул',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'магнитола',
      parts:[],
      repairCost:3500
    },
    {
      id:3,
      creationDate:new Date(2020, 9, 2),
      client:ClientService.clients[2],
      status: OrderItemStatusEnum.PaymentNeeded,
      equipment:{
        id:3,
        name:'Планшет ASUS 301LED'
      },
      defectDescription:'разбит экран',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'планшет',
      parts:[],
      repairCost:1900
    },
    {
      id:4,
      creationDate:new Date(2020, 9, 2),
      client:ClientService.clients[3],
      equipment:{
        id:4,
        name:'Ноутбук Acer 5320'
      },
      status: OrderItemStatusEnum.RepairInProgress,
      defectDescription:'зависает через 5-10 минут',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'ноутбук, БП',
      parts:[],
      repairCost:4800
    },
    {
      id:5,
      creationDate:new Date(2020, 9, 3),
      client:ClientService.clients[4],
      equipment:{
        id:5,
        name:'Ноутбук Asus F35'
      },
      status: OrderItemStatusEnum.RepairInProgress,
      defectDescription:'зависает через 5-10 минут',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'ноутбук, БП',
      parts:[],
      repairCost:5800
    },
    {
      id:6,
      creationDate:new Date(2020, 9, 3),
      client:ClientService.clients[5],
      equipment:{
        id:6,
        name:'Ноутбук Asus F55'
      },
      status: OrderItemStatusEnum.RepairInProgress,
      defectDescription:'разбита матрица',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'ноутбук, БП',
      parts:[],
      repairCost:5100
    },
    {
      id:7,
      creationDate:new Date(2020, 9, 3),
      client:ClientService.clients[6],
      equipment:{
        id:5,
        name:'Ноутбук Asus F35'
      },
      status: OrderItemStatusEnum.RepairInProgress,
      defectDescription:'разбита матрица',
      externalStateDescription:'б/у, потертости',
      diagnosticResult:null,
      complectation:'ноутбук, БП',
      parts:[],
      repairCost:6100
    }
  ];

  constructor(private http: HttpClient) { }

  public getByFilter(request: ReceptionRegistryRequest) : Promise<OrderRegistry>{

    let promise = new Promise<OrderRegistry>((resolve, reject)=>{

        // filtering
        const filterdItems:OrderRegistryItem[] = [];
        for(let index = 0; index < ReceptionService.items.length; index++){
          const item = ReceptionService.items[index];
          let matchedByText = true;
          let matchedByStatus = true;

          if(request.text){
            let name:string = null;
            if(item.client.type.id === ClientTypeEnum.Juridical.id){
              name = (<JuridicalPerson>item.client).name;
            }
            else{
              name = (<PhysicalPerson>item.client).firstName;
            }
            matchedByText = name.toLowerCase().startsWith(request.text.toLowerCase());
          }

          if(request.status){
            matchedByStatus =  item.status.id === request.status;
          }
          if(matchedByStatus && matchedByText){
            filterdItems.push(item);
          }
        }

        const pagedResult : OrderRegistry = {
          total:filterdItems.length,
          items : filterdItems.slice(request.skip, request.skip + request.take)
        };

        resolve(pagedResult);
    });

    return promise;
  }

  get(id:number): Observable<Order>{
    const result = new BehaviorSubject<Order>(null);

    const orderRegistryItem = ReceptionService.items.find((item, index) => item.id == id);
    if(orderRegistryItem){
      const order:Order = {
        id:orderRegistryItem.id,
        repairCost:orderRegistryItem.repairCost,
        client:this.createClient(orderRegistryItem.client),
        complectation:orderRegistryItem.complectation,
        creationDate:orderRegistryItem.creationDate,
        defectDescription:orderRegistryItem.defectDescription,
        equipment: {
          id: orderRegistryItem.equipment.id, 
          name: orderRegistryItem.equipment.name,
          isNode: false,
          parentId: null,
          availableComplectation: null
        },
        externalStateDescription:orderRegistryItem.externalStateDescription,
        status:orderRegistryItem.status,
        diagnosticResult:orderRegistryItem.diagnosticResult
      };

      result.next(order);
    }

    return result.asObservable();
  }

  private createClient(client: Client): JuridicalPerson | PhysicalPerson{
    if(client.type.id === ClientTypeEnum.Juridical.id){
      const juridicalPerson = <JuridicalPerson>client;
      const jp: JuridicalPerson = {
        id:1,
        type:ClientTypeEnum.Juridical,
        email:client.email,
        inn:juridicalPerson.inn,
        kpp:juridicalPerson.kpp,
        name:juridicalPerson.name,
        phone:juridicalPerson.phone
      };

      return jp;
    }
    else{
      const physicalPerson = <PhysicalPerson>client;
      const pp:PhysicalPerson = {
        id:1,
        type: ClientTypeEnum.Phisical,
        firstName:physicalPerson.firstName,
        lastName:physicalPerson.lastName,
        middleName:physicalPerson.middleName,
        email:physicalPerson.email,
        phone:physicalPerson.phone
      };

      return pp;
    }
  }
}