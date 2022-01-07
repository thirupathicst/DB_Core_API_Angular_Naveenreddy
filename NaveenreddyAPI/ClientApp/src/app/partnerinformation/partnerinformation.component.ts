import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { APIServiceService } from '../Services/apiservice.service';
import { AppConstants } from '../Services/constants.service';
import { NotificationService } from '../Services/notification.service';
//declare let toastr: any;

@Component({
  selector: 'app-partnerinformation',
  templateUrl: './partnerinformation.component.html',
  styleUrls: ['./partnerinformation.component.css']
})
export class PartnerinformationComponent implements OnInit {

  save_update: boolean = false;
  validatingForm: FormGroup;
  submitted = false;
  optionsCountries = AppConstants.Countries;
  optionsLanguages = AppConstants.Languages;
  optionsReligous = AppConstants.Religous;
  optionsMaritialStatus = AppConstants.MaritialStatus;

  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService,private notification:NotificationService, private router: Router) { }

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

  ngAfterViewInit(): void {
    this.apiService.getPartner().subscribe(resp => {
      if (resp.age > 0) {
        this.notification.showInfo('Already have details you can edit')
        this.BindControlValues(resp);
      }
    })
  }

  BindControlValues(resp) {
    this.save_update = true;
    this.validatingForm.controls.Age.setValue(resp.age);
    this.validatingForm.controls.Maritalstatus.setValue(resp.maritalstatus);
    this.validatingForm.controls.Height.setValue(resp.height);
    this.validatingForm.controls.Complexion.setValue(resp.complexion);
    this.validatingForm.controls.Religion.setValue(resp.religion);
    this.validatingForm.controls.Caste.setValue(resp.caste);
    this.validatingForm.controls.Mothertongue.setValue(resp.mothertongue);
    this.validatingForm.controls.Education.setValue(resp.education);
    this.validatingForm.controls.Occupation.setValue(resp.occupation);
    this.validatingForm.controls.Citizenof.setValue(resp.citizen);
    this.validatingForm.controls.Countryliving.setValue(resp.country);
    this.validatingForm.controls.Residestate.setValue(resp.state);
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
      "religion": this.validatingForm.controls.Religion.value,
      "mothertongue": this.validatingForm.controls.Mothertongue.value,
      "caste": this.validatingForm.controls.Caste.value,
      "education": this.validatingForm.controls.Education.value,
      "occupation": this.validatingForm.controls.Occupation.value,
      "citizen": this.validatingForm.controls.Citizenof.value,
      "country": this.validatingForm.controls.Countryliving.value,
      "state": this.validatingForm.controls.Residestate.value,
    }

    if (this.save_update) {
      this.apiService.updatePartner(partner).subscribe(resp => {
        this.notification.showSuccess('Data updated successfully')
      })
    }
    else {
      this.apiService.addPartner(partner).subscribe(resp => {
        this.notification.showSuccess('Data saved successfully')
      })
    }
    this.router.navigate(['/quicksearch']);
  }
}