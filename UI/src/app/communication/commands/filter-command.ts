import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";

export class FilterCommand extends CommandType<FilterCommandData>{
    constructor(data : FilterCommandData){
        super(CommandEnum.FilterCommand, data);
    }
}

export class FilterCommandData{
    text:string;
}
