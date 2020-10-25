import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";
import { Constants } from 'src/app/models/constants';

export class PagingCommand extends CommandType<PagingCommandData>{
    constructor(data: PagingCommandData){
        super(CommandEnum.PagingCommand, data);
    }
}

export class PagingCommandData {
    skip:number = 0;
    take:number = Constants.ReceptionRegistryPageSize;
    constructor(page: number, pageSize:number){
        this.skip = page * pageSize;
        this.take = pageSize;
    }
}