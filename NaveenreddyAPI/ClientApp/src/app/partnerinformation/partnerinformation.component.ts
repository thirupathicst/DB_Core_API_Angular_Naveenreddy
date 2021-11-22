import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-partnerinformation',
  templateUrl: './partnerinformation.component.html',
  styleUrls: ['./partnerinformation.component.css']
})
export class PartnerinformationComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.validatingForm = this.formBuilder.group({
      Age: ['', Validators.required],
      Maritalstatus: ['', Validators.required],
      Height: ['', Validators.required],
      Complexion: ['Fair', Validators.required],
      Religion: ['', Validators.required],
      Caste: ['', Validators.required],
      Mothertongue: ['', Validators.required],
      Education: ['', Validators.required],
      Occupation: ['', Validators.required],
      Citizenof: ['', Validators.required],
      Countryliving: ['', Validators.required],
      Residestate: ['', Validators.required],
      Partnerinfo: ['', Validators.required],
    })

    this.validatingForm.controls.Caste.setValue('Any');
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
