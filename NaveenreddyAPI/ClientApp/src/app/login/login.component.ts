import { Component, OnInit } from '@angular/core';
import { FormGroup,  Validators, FormBuilder } from '@angular/forms';
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
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    })
  }
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
      //alert(this.login);
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
