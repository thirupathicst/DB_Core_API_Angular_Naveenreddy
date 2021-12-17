import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  getUserToken(): string {
    return sessionStorage.getItem('token');
  }

  checkToken(): boolean {
    return !!sessionStorage.getItem('token');
  }

  getUserId(): number {
    return parseInt(localStorage.getItem('isPersonId'));
  }

  setUserAuthentication(x) {
    sessionStorage.setItem('token', x.message);
    localStorage.setItem('isPersonId', x.personId);
  }

  removeAuthentication() {
    sessionStorage.clear();
    localStorage.clear();
  }
}
