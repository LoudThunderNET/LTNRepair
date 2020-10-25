import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";
import { EnumType } from 'src/app/domain/enums/enum-type';

export class FilterStatusCommand extends CommandType<FilterStatusCommandData>{
    constructor(data: FilterStatusCommandData){
        super(CommandEnum.FilterStatusCommand, data);
    }
}

export class FilterStatusCommandData {
    constructor(public status: EnumType){}
}
