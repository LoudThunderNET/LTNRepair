import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Сервисный центр';
  items : MenuItem[] = [];

  ngOnInit(): void {
    this.items = [
      {
        label:'Приемка/Выдача', routerLink: ['/reception']
      },
      {
        label:'Ремонт', routerLink:['/repair']
      },
      {
        label:'Склад', routerLink:['/warehouse']
      },
      {
        label:'Справочники', routerLink:['/dictionary']
      },
      {
        label:'Администрирование', routerLink:['/admin']
      }
    ];
  }
}
