import { Component, OnInit } from '@angular/core';
import { ChangeRegistryViewCommand, ChangeRegistryViewCommandData, ViewType } from 'src/app/communication/commands/change-registry-view-command';
import { CommunicatorService } from 'src/app/communication/communicator.service';

@Component({
  selector: 'app-reception-registry-view-toggle',
  templateUrl: './reception-registry-view-toggle.component.html',
  styleUrls: ['./reception-registry-view-toggle.component.scss']
})
export class ReceptionRegistryViewToggleComponent implements OnInit {
  public GridView:boolean = true;

  constructor(private communicator : CommunicatorService) { }

  ngOnInit(): void {
  }

  public toggle(){
    this.GridView = !this.GridView;
    if(this.GridView)    {
      this.communicator.sendCommand(new ChangeRegistryViewCommand(new ChangeRegistryViewCommandData(ViewType.Grid)));
    }
      else{
      this.communicator.sendCommand(new ChangeRegistryViewCommand(new ChangeRegistryViewCommandData(ViewType.Card)));
    }
  }
}
