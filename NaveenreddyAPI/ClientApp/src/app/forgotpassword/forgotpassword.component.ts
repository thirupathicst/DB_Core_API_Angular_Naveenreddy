import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../apiservice.service';
import { ModalDirective } from 'angular-bootstrap-md';
import { Router } from '@angular/router';
import { timer } from 'rxjs';
declare let toastr: any;

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  validatingForm: FormGroup;
  OtpForm: FormGroup;
  submitted = false;
  submitted1 = false;
  timeLeft: number = 60;
  @ViewChild('demoBasic', { static: true }) demoBasic: ModalDirective;

  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      profileId: ['', [Validators.required, Validators.pattern("^[0-9]{10}$")]],
      emailId: ['', [Validators.required, Validators.email]],
    })

    this.OtpForm = this.formBuilder.group({
      otp: ['', [Validators.required, Validators.pattern("^[0-9]{6}$")]]
    })
  }

  get f() { return this.validatingForm.controls; }
  get f1() { return this.OtpForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.validatingForm.invalid) {
      return;
    }

    this.OTPservice()
  }

  OTPservice()
  {
    let forgotPassword = {
      EmailId: this.validatingForm.controls.emailId.value,
      MobileNo: this.validatingForm.controls.profileId.value
    }

    this.apiService.forgotPassword(forgotPassword).subscribe(resp => {
      this.showConformation();
      this.startTimer()
    })
  }

  showConformation() {
    this.demoBasic.show();
  }

  hideConfrimation() {
    this.demoBasic.hide();
  }

  onOtpSubmit() {
    this.submitted1 = true;
    if (this.OtpForm.invalid) {
      return;
    }

    this.apiService.otpVerification(this.validatingForm.controls.emailId.value, this.OtpForm.controls.otp.value).subscribe(resp => {
      this.router.navigate(['/login']);
    })
  }

  otpResend()
  {
    this.OTPservice()
  }

  startTimer(){
    this.timeLeft=60;
    const source = timer(0, 1000);
     let subscription=source.subscribe(val => {
      this.timeLeft--;
      if(val>=60)
      {
        subscription.unsubscribe()
      }
    })
  }
}