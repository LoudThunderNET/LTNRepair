import { SourceMapGenerator } from '@angular/compiler/src/output/source_map';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule } from '@angular/forms';
import { Controls, NgxSubFormComponent, subformComponentProviders } from 'ngx-sub-form';
import { PhysicalPerson } from 'src/app/domain/order/physical-person';

@Component({
  selector: 'app-physical-person',
  templateUrl: './physical-person.component.html',
  styleUrls: ['./physical-person.component.scss'],
  providers: subformComponentProviders(PhysicalPersonComponent)
})
export class PhysicalPersonComponent extends NgxSubFormComponent<PhysicalPerson> {
  constructor(){
    super();
    this.emitNullOnDestroy = false;
  }
  
  protected getFormControls(): Controls<PhysicalPerson> {
    return {
        id:new FormControl(),
        email:new FormControl(),
        firstName:new FormControl(),
        lastName:new FormControl(),
        middleName:new FormControl(),
        phone:new FormControl(),
        type:new FormControl(),
    };
  }
}
