import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RepairRoutingModule } from './repair-routing.module';
import { RepairPageComponent } from './repair-page/repair-page.component';


@NgModule({
  declarations: [RepairPageComponent],
  imports: [
    CommonModule,
    RepairRoutingModule
  ]
})
export class RepairModule { }
