import { CommandType } from '../command-type';
import { CommandEnum } from "../command-enum.enum";

export class NopCommand extends CommandType<void> {
    constructor(){
        super(CommandEnum.Nop);
    }
}