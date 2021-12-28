import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AppConstants } from '../constants.service';
@Component({
  selector: 'app-quicksearch',
  templateUrl: './quicksearch.component.html',
  styleUrls: ['./quicksearch.component.css']
})
export class QuicksearchComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  optionsCaste=AppConstants.Caste;
  optionsEducation=AppConstants.Education;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      Lookingfor: ['', Validators.required],
      Age: ['', Validators.required],
      Caste: ['', Validators.required],
      Education: ['', Validators.required],
      Height: ['', Validators.required],
      Livingin: ['', Validators.required],
    })
    this.validatingForm.controls.Lookingfor.setValue('F');
    this.validatingForm.controls.Caste.setValue('Any');
    this.validatingForm.controls.Education.setValue('Any');
    this.validatingForm.controls.Livingin.setValue('Any');
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
