import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      profileId: ['', [Validators.required, Validators.pattern("^[0-9]{10}$")]],
      emailId: ['', [Validators.required, Validators.email]],
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.validatingForm.invalid) {
      return;
    }

    console.log(JSON.stringify(this.validatingForm.value, null, 2));
    //this.validatingForm.controls.f.markAsTouched();
  }
}
