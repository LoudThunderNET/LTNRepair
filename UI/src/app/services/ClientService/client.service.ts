import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { urls } from 'src/main';
import { Client } from '../../domain/client';

@Injectable()
export class ClientService {

  constructor(private httpClient: HttpClient) { }

  /**
   * Возвращает заказчика по его идентификатору.
   * @param id Идентификатор заказчика.
   */
  public getClientById(id:number):Observable<Client>{
    return this.httpClient.get<Client>(urls.ClientApiUrl+id);
  }

  /**
   * Возвращает заказчиков отфильтрованных по вхождению строки.
   * @param filterString Строка поиска.
   */
  public getClientsByFilter(filterString:string):Observable<Client[]>{
    return this.httpClient.get<Client[]>(encodeURI(urls.ClientApiUrl+'filtered/'+filterString));
  }

  /**
   * Обновляет заказачика.
   * @param client Модель заказчика.
   */
  public updateClient(client: Client): Observable<any>{
    const bs = new Observable(null);
    
    return bs;
  }

  /**
   * Создает нового заказчика.
   * @param client Модель заказчика.
   */
  public createClient(client: Client): BehaviorSubject<number>{
    const bs = new BehaviorSubject<number>(1);
    bs.next(1);
    bs.complete();

    return bs;
  }
}
