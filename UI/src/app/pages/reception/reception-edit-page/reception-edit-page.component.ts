import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Order } from "../../../domain/order/order";
import { ConfirmationService } from 'primeng/api';
import { ReceptionService } from 'src/app/services/ReceptionService/reception.service';

@Component({
  selector: 'app-reception-edit-page',
  templateUrl: './reception-edit-page.component.html',
  styleUrls: ['./reception-edit-page.component.scss'],
  providers: [ConfirmationService]
})
export class ReceptionEditPageComponent  implements OnInit {

  isNewOrder:boolean = false;
  order: Order;
  isModified:boolean = false;
  showCloseFormConfirmation:boolean = false;

  constructor(
    private activatedRoute : ActivatedRoute, 
    private title : Title, 
    private receptionService: ReceptionService,
    private confirmationService: ConfirmationService) { 
  }

  ngOnInit(): void {
    const orderId = this.activatedRoute.snapshot.params['id'];
    if(orderId){
      this.title.setTitle(`Редактирование заказа номер ${orderId}`);

      this.receptionService.get(orderId).subscribe(r => {
        this.order = r;
        this.isNewOrder = false;
      });

    }
    else{
      this.title.setTitle('Создание заказа');
      this.isNewOrder = true;
    }
  }

  onOrderChange(order: Order){
    console.log('changed');
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
