import { CommandEnum } from './command-enum.enum';

/** Комманда взаимодействия компонентов */
export class CommandType<TData> {
    /**
     * Инициализирует команду взаимодействия компонентов.
     * @param type Тип команды.
     * @param data Данные команды.
     */
    constructor(public readonly type : CommandEnum, public readonly data : TData){

    }
}
