import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Controls, NgxSubFormComponent, subformComponentProviders } from 'ngx-sub-form';
import { JuridicalPerson } from 'src/app/domain/order/juridical-person';

@Component({
  selector: 'app-juridical-person',
  templateUrl: './juridical-person.component.html',
  styleUrls: ['./juridical-person.component.scss'],
  providers: subformComponentProviders(JuridicalPersonComponent)
})
export class JuridicalPersonComponent extends NgxSubFormComponent<JuridicalPerson> {

  protected getFormControls(): Controls<JuridicalPerson> {
    return {
      id:new FormControl(),
      name:new FormControl(),
      inn:new FormControl(),
      kpp:new FormControl(),
      email:new FormControl(),
      phone:new FormControl(),
      type:new FormControl(),
    };
  }
}
