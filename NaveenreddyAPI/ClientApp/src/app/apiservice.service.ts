import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class APIServiceService {
  public isLoading = new BehaviorSubject(false);
  private bseAPI: string;

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
    return this.http.post(`${this.bseAPI}/Account/Login`, Login);
    //return this.http.post(`${this.bseAPI}/Login`, Login, { responseType: 'text' });
  }

  public changePassword(ChangePassword: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Account/ChangePassword`, ChangePassword);
  }

  public forgotPassword(ForgotPassword: Object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Account/ForgotPassword`, ForgotPassword);
  }

  public otpVerification(emailId: string,otp:number): Observable<any> {
    return this.http.get(`${this.bseAPI}/Account/OTPVerification?OTP=${otp}&EmailId=${emailId}`);
  }

  public signOut(): Observable<any> {
    return this.http.get(`${this.bseAPI}/Account/Signout`);
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

  public uploadImages(Image: File[]): Observable<any> {
    const formData: FormData = new FormData();
    Image.forEach(item => {
      formData.append('file', item);
    });
    return this.http.post(`${this.bseAPI}/ImageUpload`, formData);
  }

  public addStory(Story: object): Observable<any> {
    return this.http.post(`${this.bseAPI}/Story`, Story);
  }

  public getPartner(): Observable<any> {
    return this.http.get(`${this.bseAPI}/PartnerInfo`);
  }

  public addPartner(Partner: object): Observable<any> {
    return this.http.post(`${this.bseAPI}/PartnerInfo`, Partner);
  }

  public updatePartner(Partner: object): Observable<any> {
    return this.http.put(`${this.bseAPI}/PartnerInfo`, Partner);
  }

  private getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'multipart/form-data');
    return headers;
  }
}
