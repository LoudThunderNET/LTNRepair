import { EnumType } from "./enum-type";

/** Тип клиента */
export class ClientTypeEnum {
    /** Физ. лицо */
    static readonly Phisical = new EnumType(1,'Физическое лицо');
    /** Юр. лицо */
    static readonly Juridical = new EnumType(2,'Юридическое лицо');
}
