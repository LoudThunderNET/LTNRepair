import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgxRootFormComponent, Controls, DataInput, subformComponentProviders, NgxAutomaticRootFormComponent } from 'ngx-sub-form';
import { Order } from 'src/app/domain/order/order';

@Component({
  selector: 'app-reception-edit',
  templateUrl: './reception-edit.component.html',
  styleUrls: ['./reception-edit.component.scss'],
  providers: subformComponentProviders(ReceptionEditComponent)
})
export class ReceptionEditComponent extends NgxAutomaticRootFormComponent<Order> {
  
  @DataInput()
  @Input('order')
  dataInput: Required<Order>;

  @Output('orderChanged')
  dataOutput: EventEmitter<Order> = new EventEmitter<Order>();
  
  protected getFormControls(): Controls<Order> {
    return {
      id: new FormControl(),
      creationDate: new FormControl(),
      client:new FormControl(),
      status:new FormControl(),
      equipment:new FormControl(),
      defectDescription:new FormControl(),
      externalStateDescription:new FormControl(),
      diagnosticResult:new FormControl(),
      complectation:new FormControl(),
      repairCost:new FormControl(),
    };
  }
}
