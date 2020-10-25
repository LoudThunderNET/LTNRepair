import { PartOrderItemStatusEnum } from "./enums/part-order-item-status-enum.enum";

/** Модель элемента заказа запчастей */
export class PartOrderItem {
    /** Идентификатор запчасти */
    id:Number;
    /** Наименование запчасти */
    name:string;
    /** Статус заказа */
    status:PartOrderItemStatusEnum;
    /** Ожидаемая дата */
    expectedDeliveryDate:Date;
}
