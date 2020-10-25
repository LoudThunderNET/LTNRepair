import { ClientTypeEnum } from "../enums/client-type-enum.enum";
import { EnumType } from "../enums/enum-type";
import { ClientBase } from './client-base';

export interface PhysicalPerson extends ClientBase {
    id:number;
    /** Тип клиента */
    type: EnumType;
    /** Имя */
    firstName?:string;
    /** Фамилия */
    lastName?:string;
    /** Отчество */
    middleName?:string;
}
