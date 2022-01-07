import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthguardService implements CanActivate {

  constructor(private router: Router, private auth: AuthService) { }

  canActivate(): boolean | Promise<boolean> {
    if (this.auth.checkToken()) {
      return true;
    }
    else {
      this.router.navigate(['/login']);
      return false;
    }
  }
}
