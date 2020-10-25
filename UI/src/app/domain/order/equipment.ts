import { EquipmentBase } from "../equipment-base";

export class Equipment extends EquipmentBase {
    availableComplectation: string[];
    isNode:boolean;
    parentId?:number;

    constructor(id:number, name:string, isNode:boolean, parentId:number, availableComplectation: string[]){
            super(id, name);
            this.availableComplectation=availableComplectation;
            this.isNode=isNode;
            this.parentId=parentId;
        }
}
