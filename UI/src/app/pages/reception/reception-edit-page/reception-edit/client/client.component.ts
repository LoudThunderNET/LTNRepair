import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Controls, FormUpdate, NgxSubFormRemapComponent, subformComponentProviders } from 'ngx-sub-form';
import { Dialog } from 'primeng/dialog';
import { BehaviorSubject, Observable } from 'rxjs';
import { Client } from 'src/app/domain/client';
import { ClientBacket } from 'src/app/domain/client-backet';
import { ClientTypeEnum } from 'src/app/domain/enums/client-type-enum.enum';
import { EnumType } from 'src/app/domain/enums/enum-type';
import { JuridicalPerson } from 'src/app/domain/order/juridical-person';
import { PhysicalPerson } from 'src/app/domain/order/physical-person';
import { ClientService } from 'src/app/services/ClientService/client.service';
import { UnreachableCase } from "../../../../../common/unreachable-case";
@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss'],
  providers: subformComponentProviders(ClientComponent)
})
export class ClientComponent extends NgxSubFormRemapComponent<Client, ClientBacket> {

  public showChooseClientDlg: boolean = false;

  public Juridical: EnumType = ClientTypeEnum.Juridical;
  public Phisical: EnumType = ClientTypeEnum.Phisical;

  public clientTypes: EnumType[] = [ClientTypeEnum.Juridical, ClientTypeEnum.Phisical];
  public selected: FormControl = new FormControl();
  public isCreating = false;
  public isEditing = false;
  public clientFilter = new FormControl(null);
  public selectedClient: Client;
  emitInitialValueOnInit = false;

  constructor(public clientService: ClientService) {
    super();
    this.setDisabledState(true);
  }

  protected transformToFormGroup(obj: Client, defaultValues: Partial<ClientBacket>): ClientBacket {
    if(!obj)
      return {
        juridical:null,
        physical:null,
        type:this.Phisical
      };

    return {
      juridical: obj.type.id === this.Juridical.id ? obj : null,
      physical: obj.type.id === this.Phisical.id ? obj : null,
      type: obj.type.id === this.Phisical.id ? this.Phisical : this.Juridical
    };
  }

  protected transformFromFormGroup(formValue: ClientBacket): Client {
    if(!formValue.type){
      return null;
    }
    switch (formValue.type.id) {
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
      type: new FormControl(null, Validators.required)
    };
  }

  //#region Event Handlers
  public onChooseClientDlgButtonClick(event) {
    this.selectedClient = null;
    this.showChooseClientDlg = true;
  }

  public async onSaveButtonClick(event) {
    if(!this.formGroup.valid)
    return;
    
    const client = this.getClientModel();

    if (client.id > 0) {
      await this.clientService.updateClient(client);
    } else {
      client.id = (await this.clientService.createClient(client)).getValue();
    }

    this.isCreating = this.isEditing = false;
    this.setDisabledState(true);
  }

  public onChooseClientDlgHiding(event) {
    this.hideDialog();
  }

  public onChooseClientClick(event) {
    const juridicalPerson: JuridicalPerson = this.selectedClient.type.id == ClientTypeEnum.Juridical.id
      ? {
        id: (this.selectedClient as JuridicalPerson).id,
        type: ClientTypeEnum.Juridical,
        email: (this.selectedClient as JuridicalPerson).email,
        inn: (this.selectedClient as JuridicalPerson).inn,
        kpp: (this.selectedClient as JuridicalPerson).kpp,
        name: (this.selectedClient as JuridicalPerson).name,
        phone: (this.selectedClient as JuridicalPerson).phone
      }
      : {
        id: 0,
        type: ClientTypeEnum.Juridical,
        email: null,
        inn: null,
        kpp: null,
        name: null,
        phone: null
      };

    const physicalPerson: PhysicalPerson = this.selectedClient.type.id == ClientTypeEnum.Phisical.id
      ? {
        id: (this.selectedClient as PhysicalPerson).id,
        type: ClientTypeEnum.Phisical,
        email: (this.selectedClient as PhysicalPerson).email,
        firstName: (this.selectedClient as PhysicalPerson).firstName,
        lastName: (this.selectedClient as PhysicalPerson).lastName,
        middleName: (this.selectedClient as PhysicalPerson).middleName,
        phone: (this.selectedClient as PhysicalPerson).phone
      }
      : {
        id: 0,
        type: ClientTypeEnum.Phisical,
        email: null,
        firstName: null,
        lastName: null,
        middleName: null,
        phone: null
      };

    this.formGroup.patchValue({
      juridical: juridicalPerson,
      physical: physicalPerson,
      type: this.selectedClient.type
    });

    this.hideDialog();
  }

  public onNewClientButtonClick(event){
    this.isCreating = true;
    this.formGroup.reset();
    this.setDisabledState(false);
  }

  public onEditClientButtonClick(event){
    this.isEditing = true;
    this.setDisabledState(false);
    this.formGroupControls.type.disable();
  }
  //#endregion

  private getClientModel() {
    const clientType = this.formGroupControls.type.value.id;
    let client = clientType == ClientTypeEnum.Juridical.id
      ? this.formGroupControls.juridical.value
      : this.formGroupControls.physical.value;

    return client;
  }

  private hideDialog() {
    this.showChooseClientDlg = false;
  }
}
