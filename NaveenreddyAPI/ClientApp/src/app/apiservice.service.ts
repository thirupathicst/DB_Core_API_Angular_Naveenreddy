import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class APIServiceService {
  bseAPI: string;
  constructor(private http: HttpClient) {
    this.bseAPI = document.getElementsByTagName('base')[0].href + 'api';
  }

  updateRegistration(Registration: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Registration`, Registration);
  }

  createRegistration(Registration: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Registration`, Registration);
  }

  createPersonalInfo(PersonalInfo: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Registration`, PersonalInfo);
  }

  createLogin(Login: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Login`, Login);
  }
}
