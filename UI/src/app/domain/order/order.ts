import { JuridicalPerson } from "./juridical-person";
import { PhysicalPerson } from "./physical-person";
import { EnumType } from '../enums/enum-type';
import { Equipment } from "./equipment";

export class Order {
    /** Номер */
    id:number;
    /** Дата создания/приемки */
    creationDate:Date;
    /** Клиент */
    client:JuridicalPerson | PhysicalPerson;
    /** Статус ремонта */
    status:EnumType;
    /** Оборудование */
    equipment:Equipment;
    /** Описание неисправности */
    defectDescription:string;
    /** Описание внешнего вида */
    externalStateDescription:string;
    /** Результат диагностики */
    diagnosticResult?:string;
    /** Комплектация */
    complectation:string;
    /** Стоимость ремонта */
    repairCost?:number;
}
