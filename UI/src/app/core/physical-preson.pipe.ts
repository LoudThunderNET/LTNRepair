import { Pipe, PipeTransform } from '@angular/core';
import { Client } from '../domain/client';
import { ClientTypeEnum } from '../domain/enums/client-type-enum.enum';
import { PhysicalPerson } from '../domain/order/physical-person';

@Pipe({
  name: 'physicalPreson'
})
export class PhysicalPresonPipe implements PipeTransform {

  transform(value: Client, ...args: unknown[]): string {
    if(!value || value.type.id == ClientTypeEnum.Juridical.id){
      return null;
    }
    const physicalPerson = value as PhysicalPerson;
    const hasFirstName = physicalPerson.firstName || physicalPerson.firstName.length;
    const hasMiddleName = physicalPerson.middleName || physicalPerson.middleName.length;

    return `${physicalPerson.lastName}${hasFirstName ? ' '+physicalPerson.firstName.substr(0, 1)+'.':null}${hasMiddleName ? ' '+physicalPerson.middleName.substr(0,1)+'.':null}`;
  }

}
