import { Component,  OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../Services/apiservice.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService,private notification:NotificationService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group(
      {
        Oldpassword: ['', Validators.required],
        Newpassword: ['', Validators.required],
        Confirmpassword: ['', Validators.required],
      },
      {
        validator: this.checkIfMatchingPasswords('Newpassword', 'Confirmpassword')
      })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    let changePassword = {
      oldPassword: this.validatingForm.controls.Oldpassword.value,
      newpassword: this.validatingForm.controls.Newpassword.value,
      confirmpassword: this.validatingForm.controls.Confirmpassword.value
    }
    this.apiService.changePassword(changePassword).subscribe(resp => {
      this.notification.showSuccess('Password changed successfully.')
    })
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
  
}
