import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Controls, NgxSubFormRemapComponent, subformComponentProviders } from 'ngx-sub-form';
import { BehaviorSubject, Observable } from 'rxjs';
import { Client } from 'src/app/domain/client';
import { ClientBacket } from 'src/app/domain/client-backet';
import { ClientTypeEnum } from 'src/app/domain/enums/client-type-enum.enum';
import { EnumType } from 'src/app/domain/enums/enum-type';
import { UnreachableCase } from "../../../../../common/unreachable-case";
@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.scss'],
  providers: subformComponentProviders(ClientFormComponent)
})
export class ClientFormComponent extends NgxSubFormRemapComponent<Client, ClientBacket> implements OnInit {

  Juridical:EnumType = ClientTypeEnum.Juridical;
  Phisical:EnumType = ClientTypeEnum.Phisical;

  types:EnumType[] = [ClientTypeEnum.Juridical, ClientTypeEnum.Phisical];
  selected:FormControl = new FormControl();
  modelChanged$:Observable<ClientBacket>;
  changed:boolean = false;

  ngOnInit(){
    this.modelChanged$ = this.formGroup.valueChanges;
  }

  protected transformToFormGroup(obj: Client, defaultValues: Partial<ClientBacket>): ClientBacket {
    return {
      juridical: obj.type.id === this.Juridical.id ? obj : null,
      physical: obj.type.id === this.Phisical.id ? obj : null,
      type:obj.type.id === this.Phisical.id ? this.Phisical : this.Juridical
    };
  }

  protected transformFromFormGroup(formValue: ClientBacket): Client {
    switch(formValue.type.id){
      case this.Juridical.id:
        return formValue.juridical;
      case this.Phisical.id:
        return formValue.physical;
      default:
        throw new UnreachableCase(formValue.type);
    }
  }

  protected getFormControls(): Controls<ClientBacket> {
    return {
      juridical: new FormControl(),
      physical: new FormControl(),
      type:new FormControl()
    };
  }

  onClientChange(basket: ClientBacket):string{
    this.changed = this.formGroup.touched;

    const clientType = this.formGroupControls.type.value.id as number;
    switch(clientType){
      case this.Juridical.id:
        this.isSaveAvailable = this.formGroupControls.juridical.value.id !== 0 && this.changed;
        break;
      case this.Phisical.id:
        this.isSaveAvailable = this.formGroupControls.physical.value.id !== 0 && this.changed;
        break;
      default:
        this.isSaveAvailable = false;
    }
    return null;
  }

  public isSaveAvailable : boolean = false;
  
}
