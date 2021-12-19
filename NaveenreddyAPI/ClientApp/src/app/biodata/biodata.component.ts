import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
  optionsSelect = AppConstants.Countries;
  optionsStates = AppConstants.States;
  optionsLanguages = AppConstants.Languages;
  optionsRaasi = AppConstants.Raasi;
  optionsCaste = AppConstants.Caste;
  optionsOccupation = AppConstants.Occupation;
  optionsReligous = AppConstants.Religous;
  constructor(private formBuilder: FormBuilder, private router: Router, private activatedRoute: ActivatedRoute, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      if (this.activatedRoute.snapshot.paramMap.get('Id') == null) {
        this.divIndex = 1;
      }
      else {
        this.divIndex = parseInt(params.get('Id')) + 1;
      }
    })

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
      BrotherOccupation: ['', Validators.required],
      NoOfSister: ['', Validators.required],
      NoOfSisterMarried: ['', Validators.required],
      NoOfSisterUnmarried: ['', Validators.required],
      SisterOccupation: ['', Validators.required],
    })

    this.partner6 = this.formBuilder.group({
      Religion: ['', Validators.required],
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

    this.registration = {
      Name: this.personal1.controls.Name.value,
      Gender: this.personal1.controls.Gender.value,
      Placeofbirth: this.personal1.controls.PlaceOfBirth.value,
      TimeOfBirth: this.personal1.controls.TimeOfBirth.value,
      Maritalstatus: this.personal1.controls.MaritalStatus.value,
      Height: this.personal1.controls.Height.value.toString(),
      Complexion: this.personal1.controls.Complexion.value,
      Mobileno: this.personal1.controls.Phone.value,
      Yourself: this.personal1.controls.Yourself.value,
      Dateofbirth: this.personal1.controls.Dateofbirth.value,
      PersonId: localStorage.getItem('isPersonId')
    }
    console.log(this.registration);
    this.apiService.createPersonalInfo(this.registration).subscribe(x => {
      this.divIndex = 2;
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

    var education = {
      Heightqualification: this.education2.controls.EducationCategory.value,
      Graducation: this.education2.controls.EducationDetails.value,
      School: this.education2.controls.SchoolName.value,
      College: this.education2.controls.College.value,
      PersonId: localStorage.getItem('isPersonId'),
    }

    this.apiService.createEducation(education).subscribe(x => {
      this.divIndex = 3;
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

  onProfessionSubmit() {
    this.submitted3 = true;

    if (this.profession3.invalid) {
      return;
    }

    var profession = {
      Yearofstart: this.profession3.controls.WorkingSince.value,
      Joblocation: this.profession3.controls.PlaceofJob.value,
      Income: this.profession3.controls.AnnualIncome.value,
      Companydetails: this.profession3.controls.OccupationDetails.value,
      Jobtype: this.profession3.controls.Jobtype.value,
      PersonId: localStorage.getItem('isPersonId'),
    }

    this.apiService.createProfessional(profession).subscribe(x => {
      this.divIndex = 4;
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

  onContactSubmit() {
    this.submitted4 = true;

    if (this.contact4.invalid) {
      return;
    }

    var address = {
      ContactAddress: this.contact4.controls.ContactAddress.value,
      Visa: this.contact4.controls.VisaStatus.value,
      Pincode: 0,
      District: this.contact4.controls.CityLivingIn.value,
      State: this.contact4.controls.StateLivingIn.value,
      Country: this.contact4.controls.CountryLivingIn.value,
      Settled: this.contact4.controls.SettledPlace.value,
      Native: this.contact4.controls.NativePlace.value,
      PermanentAddress: this.contact4.controls.CitizenOf.value,
      PersonId: localStorage.getItem('isPersonId'),
    }
    console.log(address);
    this.apiService.createAddress(address).subscribe(x => {
      this.divIndex = 5;
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

  onFamilySubmit() {
    this.submitted5 = true;

    if (this.family5.invalid) {
      return;
    }
    var family = {
      Fathername: this.family5.controls.FatherName.value,
      Mothername: this.family5.controls.MotherName.value,
      Noofbrothers: this.family5.controls.NoOfBrothers.value,
      Noofbrothersunmarrried: this.family5.controls.NoOfBrotherUnmarried.value,
      Noofbrothersmarrried: this.family5.controls.NoOfBrotherMarried.value,
      Brotheroccupation: this.family5.controls.BrotherOccupation.value,
      Fatheroccupation: this.family5.controls.FathersOccupation.value,
      Motheroccupation: this.family5.controls.MothersOccupation.value,
      Noofsisters: this.family5.controls.NoOfSister.value,
      Noofsistersmarrried: this.family5.controls.NoOfSisterMarried.value,
      Noofsistersunmarrried: this.family5.controls.NoOfSisterUnmarried.value,
      Sisteroccupation: this.family5.controls.SisterOccupation.value,
      PersonId: localStorage.getItem('isPersonId'),
    }

    this.apiService.createFamily(family).subscribe(x => {
      this.divIndex = 6;
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

  onPartnerSubmit() {
    this.submitted6 = true;

    if (this.partner6.invalid) {
      return;
    }

    var partner = {
      Religion: this.partner6.controls.Religion.value,
      Caste: this.partner6.controls.Caste.value,
      Subcaste: this.partner6.controls.SubCaste.value,
      Star: this.partner6.controls.Star.value,
      Raasi: this.partner6.controls.Raasi.value,
      Gothram: this.partner6.controls.Gothram.value,
      MotherTongue: this.partner6.controls.MotherTongue.value,
      PersonId: localStorage.getItem('isPersonId'),
    }

    this.apiService.createReligious(partner).subscribe(x => {
      console.log(x);
      this.router.navigate(['/imageupload']);
    }, err => {
      console.log(err);
    });
  }

  clickBack(e) {
    this.divIndex = e - 1;
  }
}
