import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path:'reception', loadChildren:()=> import('./pages/reception/reception.module').then(m=>m.ReceptionModule)
  },
  {
    path:'repair', loadChildren:()=> import('./pages/repair/repair.module').then(m=>m.RepairModule)
  },
  {
    path:'dictionary', loadChildren:()=> import('./pages/dictionary/dictionary.module').then(m=>m.DictionaryModule)
  },
  {
    path:'warehouse', loadChildren:()=> import('./pages/warehouse/warehouse.module').then(m=>m.WarehouseModule)
  },
  {
    path:'admin', loadChildren:()=> import('./pages/admin/admin.module').then(m=>m.AdminModule)
  },
  {
    path:'',
    redirectTo:'/reception',
    pathMatch:'full'
  },
  {
    path:'**', component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
