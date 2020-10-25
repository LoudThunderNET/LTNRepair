import { EnumType } from "./enum-type";

/** Статусы заказанной запчасти */
export class PartOrderItemStatusEnum {
    /** Заказн */
    static readonly Ordered = new EnumType(1, 'Заказан');
    /** Доставляется */
    static readonly Delivering = new EnumType(2,'Доставляется');
    /** Поступил */
    static readonly Delivered = new EnumType(3,'Поступил');
}
