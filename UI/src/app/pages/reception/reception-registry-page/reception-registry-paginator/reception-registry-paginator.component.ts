import { Component, OnInit } from '@angular/core';
import { CommandEnum } from 'src/app/communication/command-enum.enum';
import { CommandType } from 'src/app/communication/command-type';
import { PagingCommand, PagingCommandData } from 'src/app/communication/commands/paging-command';
import { ReceptionRegistryLoadedCommand } from 'src/app/communication/commands/reception-registry-loaded-command';
import { CommunicatorService } from 'src/app/communication/communicator.service';
import { Constants } from "../../../../models/constants";

@Component({
  selector: 'app-reception-registry-paginator',
  templateUrl: './reception-registry-paginator.component.html',
  styleUrls: ['./reception-registry-paginator.component.scss']
})
export class ReceptionRegistryPaginatorComponent implements OnInit {
  totalRecords:number = 0;
  pageSize:number = Constants.ReceptionRegistryPageSize;

  constructor(public communicator: CommunicatorService) { }

  ngOnInit(): void {
    this.communicator.CommandSource.subscribe(cmd=> this.handleCommand(cmd));
  }

  handleCommand(cmd : CommandType<any>){
    if(cmd.type == CommandEnum.ReceptionRegistryLoadedCommand){
      const receptionRegistryLoadedData = (<ReceptionRegistryLoadedCommand>cmd).data;
      this.totalRecords = receptionRegistryLoadedData.totalRows;
    }
  }

  onPageChange(event){
    this.communicator.sendCommand(new PagingCommand(new PagingCommandData(event.page, event.rows )));
  }
}
