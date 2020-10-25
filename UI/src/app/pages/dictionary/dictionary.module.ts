import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DictionaryRoutingModule} from './dictionary-routing.module';
import { DictionaryPageComponent } from './dictionary-page/dictionary-page.component';


@NgModule({
  declarations: [DictionaryPageComponent],
  imports: [
    CommonModule,
    DictionaryRoutingModule
  ]
})
export class DictionaryModule { }
