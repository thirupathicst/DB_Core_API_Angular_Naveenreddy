import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../apiservice.service';
import { AppConstants } from '../constants.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registration: any;
  optionsSelect = AppConstants.Filledby;
  registerForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: APIServiceService) { }

  ngOnInit(): void {

    this.registerForm = this.formBuilder.group(
      {
        FormFilledby: ['', Validators.required],
        FullName: ['', Validators.required],
        // validates date format yyyy-mm-dd
        //dob: ['', [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
        Email: ['', [Validators.required, Validators.email]],
        Password: ['', [Validators.required, Validators.minLength(6)]],
        ConfirmPassword: ['', [Validators.required]],
      },
      {
        validator: this.checkIfMatchingPasswords('Password', 'ConfirmPassword')
      }
    )
    this.registerForm.controls.FormFilledby.setValue('1');
  }

  checkIfMatchingPasswords(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (matchingControl.errors && !matchingControl.errors.confirmedValidator) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmedValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    }
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    this.registration = {
      filledby: this.registerForm.controls.FormFilledby.value,
      fullname: this.registerForm.controls.FullName.value,
      email: this.registerForm.controls.Email.value,
      password: this.registerForm.controls.Password.value,
      confirmpassword: this.registerForm.controls.ConfirmPassword.value
    }

    this.apiService.createRegistration(this.registration).subscribe(resp => {
      console.log(resp);
      localStorage.setItem('isPersonId', resp.personId);
      this.router.navigate(['/biodata']);
    }, err => { console.log(err) });
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }
}

