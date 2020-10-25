import { AbstractControl, FormControl } from '@angular/forms';
import { Controls, NgxSubFormComponent, subformComponentProviders } from 'ngx-sub-form';

export class FormControlBuilder {
    build<T>(c: { new (...[]): T } ): Controls<T>{

        const formControlObject = {};
        const value: T = new c();

        for(let key in value){
            Object.defineProperty(formControlObject, key, 
            {
                value : new FormControl()
            });
        }

        return <Controls<T>><unknown>formControlObject;
    }
}
