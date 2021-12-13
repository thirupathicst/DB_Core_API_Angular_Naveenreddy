import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../apiservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  login: any;
  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    })

    this.validatingForm.controls.userName.setValue('Ramakrishna@gmail.com');
    this.validatingForm.controls.password.setValue('Ramakrishna');
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

    this.login = {
      emailid: this.validatingForm.controls.userName.value,
      password: this.validatingForm.controls.password.value
    }

    this.apiService.createLogin(this.login).subscribe(x => {
      if (x.status == 4) {
        localStorage.setItem('isPersonId', x.personId);
        if (x.profilestage < 6) {
          this.router.navigate(['/biodata/' + x.profilestage]);
        }
        else {
          this.router.navigate(['/quicksearch']);
        }
      }
      console.log(x);
    }, err => {
      if (err.status == 500) {
        console.log(err);
      }
      else if (err.status == 400) {
        console.log(err.error);
      }
    })
    //console.log(JSON.stringify(this.validatingForm.value, null, 2));
    //this.validatingForm.controls.f.markAsTouched();
  }
}
