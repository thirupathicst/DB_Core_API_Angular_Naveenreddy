import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class APIServiceService {
  bseAPI: string;
  constructor(private http: HttpClient) {
    this.bseAPI = document.getElementsByTagName('base')[0].href + 'api';
  }

  public updateRegistration(Registration: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Registration`, Registration);
  }

  public createRegistration(Registration: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Registration`, Registration);
  }

  public createPersonalInfo(PersonalInfo: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Registration`, PersonalInfo);
  }

  public createLogin(Login: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Login`, Login, { responseType: 'text' });
  }

  public createEducation(Education: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Education`, Education);
  }

  public updateEducation(Education: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Education`, Education);
  }

  public createProfessional(Professional: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Professional`, Professional);
  }

  public updateProfessional(Professional: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Professional`, Professional);
  }

  public createAddress(Address: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Address`, Address);
  }

  public updateAddress(Address: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Address`, Address);
  }

  public createFamily(Family: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Family`, Family);
  }

  public updateFamily(Family: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Family`, Family);
  }

  public createReligious(Religious: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Religious`, Religious);
  }

  public updateReligious(Religious: Object): Observable<any> {
    return this.http.put(`${this.bseAPI}/Religious`, Religious);
  }

  public uploadImages(Image: File): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('file', Image);
    //formData.set('Content-Type', 'multipart/form-data');
    return this.http.post(`${this.bseAPI}/ImageUpload`, formData);

  }

  private getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'multipart/form-data');
    return headers;
  }
}
