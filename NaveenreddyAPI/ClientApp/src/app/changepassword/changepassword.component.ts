import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.css']
})
export class ChangepasswordComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      Oldpassword: ['', Validators.required],
      Newpassword: ['', Validators.required],
      Confirmpassword: ['', Validators.required],
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
