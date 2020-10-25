/** Типы команда */
export enum CommandEnum {
    /** Пустая команда */
    Nop = 1,

    /** Команда фильтрации */
    FilterCommand = 2,

    /** Команда фильтрации */
    FilterStatusCommand = 3,

    /** Команда пагинации */
    PagingCommand = 4,

    /** Команда оповещения о загрузке данных*/
    ReceptionRegistryLoadedCommand = 5,
    
    /** Команда изменения вида реестра */
    ChangeRegistryView = 6,
}
