import {Client} from '../client';
import {Equipment} from '../equipment';
import { PartOrderItem } from "../part-order-item";
import { EnumType } from '../enums/enum-type';

/** Модель записи реестра заказов */
export class OrderRegistryItem {
    /** Номер */
    id:number;
    /** Дата создания/приемки */
    creationDate:Date;
    /** Клиент */
    client:Client;
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
    /** Заказанные запчасти */
    parts:PartOrderItem[];
    /** Стоимость ремонта */
    repairCost?:number;
}
