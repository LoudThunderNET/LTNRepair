import { ClientTypeEnum } from "../enums/client-type-enum.enum";
import { EnumType } from "../enums/enum-type";
import { ClientBase } from "./client-base";

export interface JuridicalPerson extends ClientBase {
    /** Тип клиента */
    type: EnumType;
    /** Наименование организации */
    name?:string;
    /** ИНН */
    inn?:string;
    /** КПП */
    kpp?:string;

}
