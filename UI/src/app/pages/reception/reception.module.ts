import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceptionPageComponent } from './reception-registry-page/reception-registry-page.component';
import { ReceptionRoutingModule } from './reception-routing.module';
import { ReceptionRegistryFilterComponent } from './reception-registry-page/reception-registry-filter/reception-registry-filter.component';
import { ReceptionQuickFilterComponent } from './reception-registry-page/reception-quick-filter/reception-quick-filter.component';
import { ReceptionRegistryViewToggleComponent } from './reception-registry-page/reception-registry-view-toggle/reception-registry-view-toggle.component';
import { ReceptionRegistryTableComponent } from './reception-registry-page/reception-registry-table/reception-registry-table.component';
import { ReceptionRegistryCardComponent } from './reception-registry-page/reception-registry-card/reception-registry-card.component';
import { TabViewModule } from 'primeng/tabview';
import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { ButtonModule } from 'primeng/button';
import { ReceptionService } from "../../services/ReceptionService/reception.service";
import { ReceptionRegistryPaginatorComponent } from './reception-registry-page/reception-registry-paginator/reception-registry-paginator.component';
import { ReceptionEditPageComponent } from './reception-edit-page/reception-edit-page.component';
import { ReceptionEditComponent } from './reception-edit-page/reception-edit/reception-edit.component';
import { ClientComponent } from './reception-edit-page/reception-edit/client/client.component';
import { EquipmentComponent } from './reception-edit-page/reception-edit/equipment/equipment.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { EquipmentService } from "../../services/EquipmentService/equipment.service";
import { TreeTableModule } from 'primeng/treetable';
import {DialogModule} from 'primeng/dialog';
import {TreeModule} from 'primeng/tree';
import { JuridicalPersonComponent } from './reception-edit-page/reception-edit/client/juridical-person/juridical-person.component';
import { PhysicalPersonComponent } from './reception-edit-page/reception-edit/client/physical-person/physical-person.component';
import { OrderStatusViewComponent } from './reception-edit-page/reception-edit/order-status-view/order-status-view.component';
import { PhysicalPresonPipe } from 'src/app/core/physical-preson.pipe';
import { ClientService } from 'src/app/services/ClientService/client.service';

@NgModule({
  declarations: [
    ReceptionPageComponent, 
    ReceptionRegistryFilterComponent, 
    ReceptionQuickFilterComponent, 
    ReceptionRegistryViewToggleComponent, 
    ReceptionRegistryTableComponent, 
    ReceptionRegistryCardComponent, 
    ReceptionRegistryPaginatorComponent, 
    ReceptionEditPageComponent, 
    EquipmentComponent, 
    ClientComponent, 
    ReceptionEditComponent, 
    JuridicalPersonComponent, 
    PhysicalPersonComponent, 
    OrderStatusViewComponent,
    PhysicalPresonPipe
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    ReceptionRoutingModule,
    TabViewModule,
    PaginatorModule,
    TableModule,
    InputTextModule,
    ToggleButtonModule,
    ButtonModule,
    ConfirmDialogModule,
    TreeTableModule,
    TreeModule,
    DialogModule
  ],
  providers:[
    ReceptionService,
    EquipmentService,
    ClientService
  ]
})
export class ReceptionModule { }
