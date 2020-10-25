import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";

export class ReceptionRegistryLoadedCommand extends CommandType<ReceptionRegistryLoadedCommandData>{
    constructor(data: ReceptionRegistryLoadedCommandData){
        super(CommandEnum.ReceptionRegistryLoadedCommand, data);
    }
}

export class ReceptionRegistryLoadedCommandData {
    constructor(public readonly totalRows: number){
    }
}