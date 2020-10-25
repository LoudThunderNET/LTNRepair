import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Controls, NgxSubFormComponent, subformComponentProviders } from 'ngx-sub-form';
import { EnumType } from 'src/app/domain/enums/enum-type';

@Component({
  selector: 'app-order-status-view',
  templateUrl: './order-status-view.component.html',
  styleUrls: ['./order-status-view.component.scss'],
  providers: subformComponentProviders(OrderStatusViewComponent)
})
export class OrderStatusViewComponent extends NgxSubFormComponent<EnumType> {

  constructor() {
    super();
   }

  protected getFormControls(): Controls<EnumType> {
    return {
      id:new FormControl(),
      text:new FormControl()
    };
  }

}
