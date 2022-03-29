import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DatashareService {

  private nameSource = new BehaviorSubject<any>('');
  name = this.nameSource.asObservable()
  constructor() { }

  changeName(name: any) {
    this.nameSource.next(name);
  }

}
