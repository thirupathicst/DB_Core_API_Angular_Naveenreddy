import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../Services/apiservice.service';
import { AppConstants } from '../Services/constants.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  optionsSelect = AppConstants.Filledby;
  registerForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: APIServiceService,private notification:NotificationService) { }

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

    let registration = {
      filledby: this.optionsSelect.filter(x => x.value == this.registerForm.controls.FormFilledby.value)[0].label,
      fullname: this.registerForm.controls.FullName.value,
      email: this.registerForm.controls.Email.value,
      password: this.registerForm.controls.Password.value,
      confirmpassword: this.registerForm.controls.ConfirmPassword.value
    }
    this.apiService.createRegistration(registration).subscribe(resp => {
      this.notification.showSuccess('Account created successfully, Please login to continue.')
      this.router.navigate(['/biodata']);
    });
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }
}

