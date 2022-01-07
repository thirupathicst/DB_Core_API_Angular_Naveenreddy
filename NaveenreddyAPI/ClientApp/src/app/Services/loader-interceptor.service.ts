import { Injectable } from '@angular/core';
import { HttpResponse, HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIServiceService } from './apiservice.service';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import { NotificationService } from './notification.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
  private requests: HttpRequest<any>[] = [];

  constructor(private loaderService: APIServiceService, private auth: AuthService,private notification:NotificationService, private router: Router) { }

  removeRequest(req: HttpRequest<any>) {
    const i = this.requests.indexOf(req);
    if (i >= 0) {
      this.requests.splice(i, 1);
    }
    this.loaderService.isLoading.next(this.requests.length > 0);
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //Add Authorization
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getUserToken()}`
      }
    });
    this.requests.push(req);

    console.log("No of requests--->" + this.requests.length);

    this.loaderService.isLoading.next(true);
    return Observable.create(observer => {
      const subscription = next.handle(req)
        .subscribe(
          event => {
            if (event instanceof HttpResponse) {
              this.removeRequest(req);
              observer.next(event);
            }
          },
          err => {
            if (err.status == 401) {
              this.auth.removeAuthentication()
              this.notification.showError('Unauthorized - Sorry, your session was expired');
              this.router.navigate(['/login']);
            }
            else if (err.status == 400) {
              if (err.error.message != undefined) {
                this.notification.showError(err.error.message)
              }
              else if (err.error.title != undefined) {
                this.notification.showError(err.error.title)
              }
              else {
                this.notification.showError(err.error)
              }
            }
            else if (err.status == 404) {
              this.notification.showError('Requested url not found')
            }
            else if (err.status == 500) {
              this.notification.showError(err.error.message)
            }
            this.removeRequest(req);
            observer.error(err);
          },
          () => {
            this.removeRequest(req);
            observer.complete();
          });
      // remove request from queue when cancelled
      return () => {
        this.removeRequest(req);
        subscription.unsubscribe();
      };
    });
  }
}

