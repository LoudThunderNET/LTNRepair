import { EnumType } from "./enum-type";

/** Статус заказа на ремонт */
export class OrderItemStatusEnum {
    /** Принят */
    static readonly Recieved = new EnumType(1, 'Принят');
    /** Диагностика */
    static readonly Diagnostics = new EnumType(2, 'Диагностика');
    /** Диагностика завершена */
    static readonly DiagnosticsCompleted = new EnumType(3, 'Диагностика завершена');
    /** Заказ деталей */
    static readonly PartsOrdering = new EnumType(4, 'Заказ деталей');
    /** Детали поступили */
    static readonly PartsDelivered = new EnumType(5, 'Детали поступили');
    /** В работе */
    static readonly RepairInProgress = new EnumType(6, 'В работе');
    /** Требуется оплата */
    static readonly PaymentNeeded = new EnumType(7, 'Требуется оплата');
    /** Завершено */
    static readonly Completed = new EnumType(8, 'Завершено');
}
