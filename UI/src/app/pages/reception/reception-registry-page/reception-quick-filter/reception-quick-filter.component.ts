import { Component, OnInit } from '@angular/core';
import { FilterStatusCommand, FilterStatusCommandData } from 'src/app/communication/commands/filter-status-command-data';
import { CommunicatorService } from 'src/app/communication/communicator.service';
import { EnumType } from 'src/app/domain/enums/enum-type';
import { OrderItemStatusEnum } from 'src/app/domain/enums/order-item-status-enum.enum';

@Component({
  selector: 'app-reception-quick-filter',
  templateUrl: './reception-quick-filter.component.html',
  styleUrls: ['./reception-quick-filter.component.scss']
})
export class ReceptionQuickFilterComponent implements OnInit {
  currentStatus?:EnumType = null;
  statuses:EnumType[] = [
    null,
    OrderItemStatusEnum.DiagnosticsCompleted,
    OrderItemStatusEnum.PaymentNeeded
  ];

  constructor(private communicator : CommunicatorService) { }

  ngOnInit(): void {
  }

  onTabChange(event:any){
    this.communicator.sendCommand(new FilterStatusCommand(new FilterStatusCommandData(this.statuses[event.index])));
  }
}
