import { Component, OnInit } from '@angular/core';
import { CommandEnum } from 'src/app/communication/command-enum.enum';
import { CommandType } from 'src/app/communication/command-type';
import { CommunicatorService } from "../../../../communication/communicator.service";
import { FilterCommand, FilterCommandData } from "../../../../communication/commands/filter-command";
@Component({
  selector: 'app-reception-registry-filter',
  templateUrl: './reception-registry-filter.component.html',
  styleUrls: ['./reception-registry-filter.component.scss']
})
export class ReceptionRegistryFilterComponent implements OnInit {
  searchedText:string = null;
  expandFilterOpened:boolean = false;
  
  constructor(private communicator : CommunicatorService) { }

  ngOnInit(): void {
  }

  onSearchButtonClick(event:any){
    this.communicator.sendCommand(new FilterCommand({ text:this.searchedText }));
  }

  onSearchTextKeyPressed(event:any){
    if(event.keyCode === 13){
      this.communicator.sendCommand(new FilterCommand({ text:this.searchedText }));
    }
  }
}
