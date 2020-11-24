import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Order } from "../../../domain/order/order";
import { ConfirmationService } from 'primeng/api';
import { ReceptionService } from 'src/app/services/ReceptionService/reception.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-reception-edit-page',
  templateUrl: './reception-edit-page.component.html',
  styleUrls: ['./reception-edit-page.component.scss'],
  providers: [ConfirmationService]
})
export class ReceptionEditPageComponent  implements OnInit {

  isNewOrder:boolean = false;
  order$: Observable<Order>;
  isModified:boolean = false;
  showCloseFormConfirmation:boolean = false;

  constructor(
    private activatedRoute : ActivatedRoute, 
    private title : Title, 
    private receptionService: ReceptionService,
    private confirmationService: ConfirmationService) { 
  }

  ngOnInit():void {
    const orderId = this.activatedRoute.snapshot.params['id'];
    if(orderId){
      this.title.setTitle(`Редактирование заказа номер ${orderId}`);

      this.order$ = this.receptionService.get(orderId)
      .pipe(
        tap({ complete: ()=> this.isModified = false})
        );

    }
    else{
      this.title.setTitle('Создание заказа');
      this.isNewOrder = true;
    }
  }

  onOrderChange(order: Order){
//    console.log('changed');
    this.isModified = true;
  }

  onCancelButtonClick(event){
    if(this.isModified){
      this.confirmationService.confirm({
        header:'Запрос',
        message:'Данные не сохранены. Вы действительно хотете перейти ?',
        accept:()=>this.navigateBack()
      });
    }
    else{
      this.navigateBack();
    }
  }
  
  private navigateBack(){
    window.history.back();
  }
}
