import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";

export class ChangeRegistryViewCommand extends CommandType<ChangeRegistryViewCommandData>{
    constructor(data: ChangeRegistryViewCommandData){
        super(CommandEnum.ChangeRegistryView, data);
    }
}

export class ChangeRegistryViewCommandData {
    constructor(public viewType:ViewType){
    }
}

export enum ViewType{
    Grid = 1,
    Card = 2
}