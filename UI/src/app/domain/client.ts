import { EnumType } from './enums/enum-type';
import { JuridicalPerson } from './order/juridical-person';
import { PhysicalPerson } from './order/physical-person';

/** Модель клиента */
export type Client = JuridicalPerson | PhysicalPerson;
