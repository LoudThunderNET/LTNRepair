import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReceptionEditPageComponent } from './reception-edit-page/reception-edit-page.component';
import { ReceptionPageComponent } from './reception-registry-page/reception-registry-page.component';

const routes: Routes = [
  {
    path: 'registry',
    component: ReceptionPageComponent
  },
  {
    path: 'edit/:id',
    component: ReceptionEditPageComponent
  },
  {
    path: 'create',
    component: ReceptionEditPageComponent
  },
  {
    path: '', redirectTo:'registry', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReceptionRoutingModule { }
