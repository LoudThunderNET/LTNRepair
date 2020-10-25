import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Client } from '../../domain/client';
import { ClientTypeEnum } from '../../domain/enums/client-type-enum.enum';
import {ReceptionModule} from '../../pages/reception/reception.module';
import {JuridicalPerson} from '../../domain/order/juridical-person';
import {PhysicalPerson} from '../../domain/order/physical-person';

@Injectable({
  providedIn: ReceptionModule
})
export class ClientService {
  public static clients: Client []=[
    {
      id:1,
      type:ClientTypeEnum.Phisical,
      firstName:'Виктор', 
      lastName:'Иванов', 
      middleName:'Петрович',
      phone:'+7-958-661-45-87',
      email:null,
      inn:null,
      kpp: null,
      name: null
    },
    {
      id: 2,
      type: ClientTypeEnum.Phisical,
      lastName:'Петров', 
      firstName:'Иван', 
      middleName:'Иванович',
      email:'ivanov@ya.ru',
      phone: null,
      inn:null,
      kpp: null,
      name: null
    },
    {
      id:3,
      type: ClientTypeEnum.Phisical,
      lastName:'Сидоренко', 
      firstName:'Андрей', 
      middleName:'Павлович',
      email:null,
      phone:'+7-922-789-56-21',
      inn:null,
      kpp: null,
      name: null
    },
    {
      id:4,
      type: ClientTypeEnum.Phisical,
      lastName:'Варчук', 
      firstName:'Олег', 
      middleName:'Ильич',
      email:'face@mai.ru',
      phone:null,
      inn:null,
      kpp: null,
      name: null
    },
    {
      id:5,
      type: ClientTypeEnum.Phisical,
      lastName:'Кривчиков', 
      firstName:'Евгений', 
      middleName:'Петрович',
      email:'t.center@mai.ru',
      phone:null,
      inn:null,
      kpp: null,
      name: null
    },
    {
      id:6,
      type: ClientTypeEnum.Phisical,
      lastName:'Строгова', 
      firstName:'Татьяна', 
      middleName:'Андреевна',
      email:'t.strogova@gmail.com',
      phone:null,
      inn:null,
      kpp: null,
      name: null
    },
    {
      id:7,
      type: ClientTypeEnum.Phisical,
      lastName:'Путин', 
      firstName:'Вовка', 
      middleName:'Вовкович',
      email:'putin@kremlin.ru',
      phone:null,
      inn:null,
      kpp: null,
      name: null
    }
  ];

  constructor(private httpClient: HttpClient) { }

  /**
   * Возвраща заказчика по его идентификатору.
   * @param id Идентификатор заказчика.
   */
  public getClientById(id:number):Observable<Client>{
    const client = ClientService.clients.find((e,i,a)=> e.id == id);

    const bs = new BehaviorSubject<Client>(client);
    return bs.asObservable();
  }

  /**
   * Возвращает заказчиков отфильтрованных по вхождению строки.
   * @param filterString Строка поиска.
   */
  public getClientsByFilter(filterString:string):Observable<Client[]>{
    const matchedClients = ClientService.clients.filter((e,i,a)=> {
      if(e.type.id === ClientTypeEnum.Juridical.id){
        return this.matchAgainstJuridicalPerson(filterString, <JuridicalPerson>e);
      } else {
        return this.matchAgainstPhysicalPerson(filterString, <PhysicalPerson>e);
      };
    });

    const bs = new BehaviorSubject<Client[]>(matchedClients);
    return bs.asObservable();
  }

  /**
   * Обновляет заказачика.
   * @param client Модель заказчика.
   */
  public updateClient(client: Client): Observable<number>{
    return new BehaviorSubject<number>(1).asObservable();
  }

  /**
   * Создает нового заказчика.
   * @param client Модель заказчика.
   */
  public createClient(client: Client): Observable<number>{
    return new BehaviorSubject<number>(1).asObservable();
  }

  private matchAgainstJuridicalPerson(filterString: string, juridicalPerson: JuridicalPerson):boolean{
    const lowerCasedFilter = filterString.toLowerCase();
    return juridicalPerson.name.toLowerCase().startsWith(lowerCasedFilter) ||
          juridicalPerson.inn.toLowerCase().startsWith(lowerCasedFilter) ||
          juridicalPerson.kpp.toLowerCase().startsWith(lowerCasedFilter) ||
          juridicalPerson.email.toLowerCase().startsWith(lowerCasedFilter) ||
          juridicalPerson.phone.toLowerCase().startsWith(lowerCasedFilter);
  }

  private matchAgainstPhysicalPerson(filterString: string, physicalPerson: PhysicalPerson):boolean{
    const lowerCasedFilter = filterString.toLowerCase();
    return physicalPerson.firstName.toLowerCase().startsWith(lowerCasedFilter) ||
          physicalPerson.lastName.toLowerCase().startsWith(lowerCasedFilter) ||
          physicalPerson.middleName.toLowerCase().startsWith(lowerCasedFilter) ||
          physicalPerson.email.toLowerCase().startsWith(lowerCasedFilter) ||
          physicalPerson.phone.toLowerCase().startsWith(lowerCasedFilter);
  }
}
