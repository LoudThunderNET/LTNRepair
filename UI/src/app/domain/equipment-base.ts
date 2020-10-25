/** Модель оборудования */
export class EquipmentBase {
    /** Идентификатор обродования в справочнике */
    id:number;
    /** Наименование */
    name:string;

    constructor(id:number, name:string){
        this.id=id;
        this.name=name;
    }
}
