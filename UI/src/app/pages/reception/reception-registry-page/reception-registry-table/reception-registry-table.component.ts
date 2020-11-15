import { Component, OnInit } from '@angular/core';
import { CommunicatorService } from 'src/app/communication/communicator.service';
import { OrderRegistryItem } from 'src/app/domain/registry/order-registry-item';
import { ReceptionService } from 'src/app/services/ReceptionService/reception.service';
import { ClientTypeEnum } from "../../../../domain/enums/client-type-enum.enum";
import { ReceptionRegistryLoadedCommand } from "../../../../communication/commands/reception-registry-loaded-command";
import { CommandType } from 'src/app/communication/command-type';
import { CommandEnum } from 'src/app/communication/command-enum.enum';
import { PagingCommand, PagingCommandData } from "src/app/communication/commands/paging-command";
import { Constants } from 'src/app/models/constants';
import { FilterCommand, FilterCommandData } from 'src/app/communication/commands/filter-command';
import { FilterStatusCommand, FilterStatusCommandData } from 'src/app/communication/commands/filter-status-command-data';
import { EnumType } from 'src/app/domain/enums/enum-type';

@Component({
  selector: 'app-reception-registry-table',
  templateUrl: './reception-registry-table.component.html',
  styleUrls: ['./reception-registry-table.component.scss']
})
export class ReceptionRegistryTableComponent implements OnInit {
  Items : OrderRegistryItem[];
  Phisical : EnumType = ClientTypeEnum.Phisical;
  Juridical : EnumType = ClientTypeEnum.Juridical;

  private paging : PagingCommandData = { skip : 0, take : Constants.ReceptionRegistryPageSize };
  private filter : FilterCommandData = { text : null };
  private filterStatus: FilterStatusCommandData;

  constructor(private receptionService : ReceptionService, public communicator: CommunicatorService) { }

  ngOnInit() {
    this.loadRegistry(0, Constants.ReceptionRegistryPageSize, null, null);
  }
  
  loadRegistry(skip:number, take:number, text:string, status:number){
    this.receptionService.getByFilter({
      skip: skip,
      take: take,
      text: text,
      status: status
    }).then(r => {
      this.Items = r.items;
      this.communicator.sendCommand(new ReceptionRegistryLoadedCommand({ totalRows: r.total }));
    });
  }

  handleCommand(cmd: CommandType<any>):string{
    let needLoad = true;
    switch(cmd.type){
      case CommandEnum.PagingCommand:{
        this.paging = (<PagingCommand>cmd).data;
        break;
      }
      case CommandEnum.FilterCommand:{
        this.filter = (<FilterCommand>cmd).data;
        break;
      }
      case CommandEnum.FilterStatusCommand:{
        this.filterStatus = (<FilterStatusCommand>cmd).data;
        break;
      }
      default:{
        needLoad = false;
      }
    }

    if(needLoad){
      this.loadRegistry(this.paging.skip, this.paging.take, this.filter.text, this.filterStatus && this.filterStatus.status && this.filterStatus.status.id);
    }

    return null;
  }
}
