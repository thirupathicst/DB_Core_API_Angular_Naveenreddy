import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../Services/apiservice.service';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private router: Router, private auth: AuthService, private apiService: APIServiceService) { }

  ngOnInit(): void {
    
    this.validatingForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    })

  }

  //updatevalues() {
  //  this.validatingForm.setValue({
  //    userName: 'Ramakrishna@gmail.com',
  //    password: 'Ramakrishna'
  //  })
  //}

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    let login = {
      emailid: this.validatingForm.controls.userName.value,
      password: this.validatingForm.controls.password.value
    }

    this.apiService.createLogin(login).subscribe(x => {
      if (x.status == 4) {
        this.auth.setUserAuthentication(x);
        //localStorage.setItem('isPersonId', x.personId);
        //sessionStorage.setItem('token', x.message);
        if (x.profilestage < 6) {
          this.router.navigate(['/biodata/' + x.profilestage]);
        }
        else {
          this.router.navigate(['/quicksearch']);
        }
      }
    })
  }
}
