import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReceptionModule } from './pages/reception/reception.module';
import { RepairModule } from './pages/repair/repair.module';
import { DictionaryModule } from './pages/dictionary/dictionary.module';
import { WarehouseModule } from './pages/warehouse/warehouse.module';
import { AdminModule } from './pages/admin/admin.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenubarModule } from 'primeng/menubar';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { CommunicatorService } from './communication/communicator.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormControlBuilder } from './common/form-control-builder';
import { PhysicalPresonPipe } from './core/physical-preson.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MenubarModule,
    HttpClientModule,
    ReceptionModule,
    RepairModule,
    DictionaryModule,
    WarehouseModule,
    AdminModule
  ],
  providers: [CommunicatorService, FormControlBuilder],
  bootstrap: [AppComponent]
})
export class AppModule { }
