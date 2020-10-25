import { EnumType } from "./enums/enum-type";
import { JuridicalPerson } from "./order/juridical-person";
import { PhysicalPerson } from "./order/physical-person";

export class ClientBacket {
    type:EnumType;
    physical: PhysicalPerson;
    juridical: JuridicalPerson;
}
