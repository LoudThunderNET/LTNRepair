import { OrderRegistryItem} from './order-registry-item';

/** Модель реестра заказов */
export class OrderRegistry {
    /** Общее количество записей согласно фильтру без пагинации */
    total:number = 0;
    /** Записи, соответствующие фильтру */
    items: OrderRegistryItem[] = [];
}
