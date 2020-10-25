import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { CommandEnum } from 'src/app/communication/command-enum.enum';
import { CommandType } from 'src/app/communication/command-type';
import { CommunicatorService } from 'src/app/communication/communicator.service';
import { ChangeRegistryViewCommand, ViewType } from "../../../communication/commands/change-registry-view-command";

@Component({
  selector: 'app-reception-page',
  templateUrl: './reception-registry-page.component.html',
  styleUrls: ['./reception-registry-page.component.scss']
})
export class ReceptionPageComponent implements OnInit {
  showGrid:boolean = true;
  showCard:boolean = false;

  constructor(private communicator : CommunicatorService, private title : Title) { 
    this.title.setTitle('Реестр заказов');
  }

  ngOnInit(): void {
    this.communicator.CommandSource.subscribe(cmd=>this.handleCommand(cmd));
  }

  handleCommand(cmd : CommandType<any>){
    if(cmd.type === CommandEnum.ChangeRegistryView){
      const changeRegistryViewCommandData = (<ChangeRegistryViewCommand>cmd).data;

      this.showCard = changeRegistryViewCommandData.viewType === ViewType.Card;
      this.showGrid = changeRegistryViewCommandData.viewType === ViewType.Grid;
    }
  }
}
