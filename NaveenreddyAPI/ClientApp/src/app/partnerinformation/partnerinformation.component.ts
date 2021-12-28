import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../apiservice.service';
import { AppConstants } from '../constants.service';

@Component({
  selector: 'app-partnerinformation',
  templateUrl: './partnerinformation.component.html',
  styleUrls: ['./partnerinformation.component.css']
})
export class PartnerinformationComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  optionsCountries = AppConstants.Countries;
  optionsLanguages = AppConstants.Languages;
  optionsReligous = AppConstants.Religous;

  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService, private router: Router) { }

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
    })

    this.validatingForm.controls.Caste.setValue('Any');
  }

 public ngAfterViewInit():void
  {
    this.apiService.getPartner().subscribe(resp=>{
      console.log(resp)
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    let partner = {
      "age": this.validatingForm.controls.Age.value,
      "height": this.validatingForm.controls.Height.value,
      "maritalstatus": this.validatingForm.controls.Maritalstatus.value,
      "complexion": this.validatingForm.controls.Complexion.value,
      "region": this.validatingForm.controls.Religion.value,
      "mothertongue": this.validatingForm.controls.Mothertongue.value,
      "caste": this.validatingForm.controls.Caste.value,
      "education": this.validatingForm.controls.Education.value,
      "occupation": this.validatingForm.controls.Occupation.value,
      "citizen": this.validatingForm.controls.Citizenof.value,
      "country": this.validatingForm.controls.Countryliving.value,
      "state": this.validatingForm.controls.Residestate.value,
    }

    this.apiService.addPartner(partner).subscribe(resp => {
      this.router.navigate(['/quicksearch']);
    })
  }

}


