import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RepairPageComponent } from "./repair-page/repair-page.component";

const routes: Routes = [
  {
    path: '',
    component: RepairPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RepairRoutingModule { }
