import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { constants } from 'buffer';
import { APIServiceService } from '../apiservice.service';
import { AppConstants } from '../constants.service';

@Component({
  selector: 'app-biodata',
  templateUrl: './biodata.component.html',
  styleUrls: ['./biodata.component.css']
})
export class BiodataComponent implements OnInit {
  registration: any;
  personal1: FormGroup;
  education2: FormGroup;
  profession3: FormGroup;
  contact4: FormGroup;
  family5: FormGroup;
  partner6: FormGroup;

  submitted = false;
  submitted2 = false;
  submitted3 = false;
  submitted4 = false;
  submitted5 = false;
  submitted6 = false;

  divIndex: number = 1;
  optionsSelect= AppConstants.Countries;
  optionsStates=AppConstants.States;
  optionsLanguages=AppConstants.Languages;
  optionsRaasi=AppConstants.Raasi;
  optionsCaste = AppConstants.Caste;
  optionsOccupation = AppConstants.Occupation;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService) { }

  ngOnInit(): void {

    this.education2 = this.formBuilder.group({
      EducationCategory: ['', Validators.required],
      EducationDetails: ['', Validators.required],
      SchoolName: ['', Validators.required],
      College: ['', Validators.required],
    })

    this.profession3 = this.formBuilder.group({
      Occupation: ['', Validators.required],
      OccupationDetails: ['', Validators.required],
      CompanyName: ['', Validators.required],
      PlaceofJob: ['', Validators.required],
      WorkingSince: ['', [Validators.required, Validators.pattern("^[0-9]{4}$")]],
      AnnualIncome: ['', Validators.required],
      Jobtype: ['', Validators.required],
    })

    this.contact4 = this.formBuilder.group({
      CitizenOf: ['', Validators.required],
      CountryLivingIn: ['', Validators.required],
      VisaStatus: ['', Validators.required],
      StateLivingIn: ['', Validators.required],
      CityLivingIn: ['', Validators.required],
      NativePlace: ['', Validators.required],
      SettledPlace: ['', Validators.required],
      ContactAddress: ['', Validators.required],

      Region: ['', Validators.required],
    })

    this.family5 = this.formBuilder.group({

      FatherName: ['', Validators.required],
      FathersOccupation: ['', Validators.required],
      MotherName: ['', Validators.required],
      MothersOccupation: ['', Validators.required],
      NoOfBrothers: ['', Validators.required],
      NoOfBrotherMarried: ['', Validators.required],
      NoOfBrotherUnmarried: ['', Validators.required],
      NoOfSisterMarried: ['', Validators.required],
      NoOfSisterUnmarried: ['', Validators.required],
      AboutYourFamily: ['', Validators.required],

    })

    this.partner6 = this.formBuilder.group({
      Region: ['', Validators.required],
      Caste: ['', Validators.required],
      SubCaste: ['', Validators.required],
      Star: ['', Validators.required],
      Raasi: ['', Validators.required],
      Gothram: ['', Validators.required],
      MotherTongue: ['', Validators.required],
    });


    this.personal1 = this.formBuilder.group({
      Name: ['', Validators.required],
      Gender: ['', Validators.required],
      PlaceOfBirth: ['', Validators.required],
      TimeOfBirth: ['', Validators.required],
      MaritalStatus: ['', Validators.required],
      Height: ['', [Validators.required, Validators.min(4), Validators.max(8)]],
      Complexion: ['', Validators.required],
      //Age: ['', [Validators.required, Validators.min(18), Validators.max(60)]],
      Yourself: ['', Validators.required],
      Dateofbirth: ['', Validators.required],
      Phone: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],

    });
  }

  get f() { return this.personal1.controls; }
  get f2() { return this.education2.controls; }
  get f3() { return this.profession3.controls; }
  get f4() { return this.contact4.controls; }
  get f5() { return this.family5.controls; }
  get f6() { return this.partner6.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.personal1.invalid) {
      return;
    }

    this.divIndex = 2;

    this.registration = {
      Name: this.personal1.controls.Name.value,
      Gender: this.personal1.controls.Gender.value,
      email: this.personal1.controls.PlaceOfBirth.value,
      TimeOfBirth: this.personal1.controls.TimeOfBirth.value,
      confirmpassword: this.personal1.controls.MaritalStatus.value,
      Height: this.personal1.controls.Height.value,
      Complexion: this.personal1.controls.Complexion.value,
      Mobileno: this.personal1.controls.Phone.value,
      Yourself: this.personal1.controls.Yourself.value,
      Dateofbirth: this.personal1.controls.Dateofbirth.value,
    }

    this.apiService.createPersonalInfo(this.registration).subscribe(x => {
      //this.router.navigate(['/biodata']);
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

  onEducationSubmit() {
    this.submitted2 = true;
    if (this.education2.invalid) {
      return;
    }

    this.divIndex = 3;
  }

  onProfessionSubmit() {
    this.submitted3 = true;

    if (this.profession3.invalid) {
      return;
    }
    this.divIndex = 4;
  }

  onContactSubmit() {
    this.submitted4 = true;

    if (this.profession3.invalid) {
      return;
    }
    this.divIndex = 5;
  }

  onFamilySubmit() {
    this.submitted5 = true;

    if (this.family5.invalid) {
      return;
    }
    this.divIndex = 6;
  }

  onPartnerSubmit() {
    this.submitted6 = true;

    if (this.partner6.invalid) {
      return;
    }
  }
}
