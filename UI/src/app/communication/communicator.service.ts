import { Directive, Injectable } from '@angular/core';
import { BehaviorSubject, Observable} from 'rxjs';
import { CommandType } from './command-type';
import { NopCommand } from "./commands/nop-command";

/** Директива взаимодействия компонентов */
@Injectable()
export class CommunicatorService {
  private state = new BehaviorSubject<CommandType<any>>(new NopCommand());

  /** Источник команды */
  public CommandSource = this.state.asObservable();

  //constructor() { }

  ngOnInit() { }
  
  /**
   * Отправляет команду подпискам.
   * @param cmd Команда.
   */
  sendCommand(cmd: CommandType<any>){
    this.state.next(cmd);
  }
}
