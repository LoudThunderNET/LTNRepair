/** Модель оборудования */
export interface Equipment {
    /** Идентификатор обродования в справочнике */
    id:number;
    
    /** Наименование */
    name:string;

    /** Список доступных опций комплектации */
    availableComplectation: string[];

    /** Признак группы */
    isNode:boolean;

    /** Ссылка на родительскую запись */
    parentId?:number;
}
