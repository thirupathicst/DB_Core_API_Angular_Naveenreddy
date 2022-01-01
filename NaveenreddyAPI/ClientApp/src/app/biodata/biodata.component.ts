import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { APIServiceService } from '../apiservice.service';
import { AppConstants } from '../constants.service';

@Component({
  selector: 'app-biodata',
  templateUrl: './biodata.component.html',
  styleUrls: ['./biodata.component.css']
})
export class BiodataComponent implements OnInit {
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

  editBiodata: boolean = false;

  divIndex: number = 1;
  optionsSelect = AppConstants.Countries;
  optionsStates = AppConstants.States;
  optionsLanguages = AppConstants.Languages;
  optionsRaasi = AppConstants.Raasi;
  optionsCaste = AppConstants.Caste;
  optionsOccupation = AppConstants.Occupation;
  optionsReligous = AppConstants.Religous;
  optionsEducation = AppConstants.Education;
  optionsJobType = AppConstants.JobType;
  optionsVisaType = AppConstants.VisaType;
  optionsRegion = AppConstants.Region;
  optionsMaritial = AppConstants.MaritialStatus;

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
      CountryLivingIn: ['', Validators.required],
      VisaStatus: ['', Validators.required],
      StateLivingIn: ['', Validators.required],
      CityLivingIn: ['', Validators.required],
      NativePlace: ['', Validators.required],
      SettledPlace: ['', Validators.required],
      ContactAddress: ['', Validators.required],
      PerminentAddress: ['', Validators.required],
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
      Yourself: ['', Validators.required],
      Dateofbirth: ['', Validators.required],
      Phone: ['', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]],
    }, {
      validator: this.dateValidator('Dateofbirth')
    });
  }

  get f() { return this.personal1.controls; }
  get f2() { return this.education2.controls; }
  get f3() { return this.profession3.controls; }
  get f4() { return this.contact4.controls; }
  get f5() { return this.family5.controls; }
  get f6() { return this.partner6.controls; }

  ngAfterViewInit(): void {
    if (this.editBiodata) {
      this.apiService.getBioData().subscribe(resp => {

        this.personal1.controls.Name.setValue(resp[0].name)
        this.personal1.controls.Gender.setValue(resp[0].gender)
        this.personal1.controls.PlaceOfBirth.setValue(resp[0].placeofbirth)
        this.personal1.controls.TimeOfBirth.setValue(resp[0].timeofbirth)
        this.personal1.controls.MaritalStatus.setValue(resp[0].maritalstatus)
        this.personal1.controls.Height.setValue(resp[0].height)
        this.personal1.controls.Complexion.setValue(resp[0].complexion)
        this.personal1.controls.Yourself.setValue(resp[0].yourself)
        this.personal1.controls.Dateofbirth.setValue(formatDate(resp[0].dateofbirth, 'yyyy-MM-dd', 'en'))
        this.personal1.controls.Phone.setValue(resp[0].mobileno)

        this.education2.controls.EducationCategory.setValue(resp[1].heightqualification)
        this.education2.controls.EducationDetails.setValue(resp[1].graducation)
        this.education2.controls.SchoolName.setValue(resp[1].school)
        this.education2.controls.College.setValue(resp[1].college)

        this.profession3.controls.Occupation.setValue(resp[2].companydetails)
        this.profession3.controls.OccupationDetails.setValue(resp[2].companydetails)
        this.profession3.controls.CompanyName.setValue(resp[2].companydetails)
        this.profession3.controls.PlaceofJob.setValue(resp[2].joblocation)
        this.profession3.controls.WorkingSince.setValue(resp[2].yearofstart)
        this.profession3.controls.AnnualIncome.setValue(resp[2].income)
        this.profession3.controls.Jobtype.setValue(resp[2].jobtype)

        this.contact4.controls.CountryLivingIn.setValue(resp[3].country)
        this.contact4.controls.VisaStatus.setValue(resp[3].visa)
        this.contact4.controls.StateLivingIn.setValue(resp[3].state)
        this.contact4.controls.CityLivingIn.setValue(resp[3].district)
        this.contact4.controls.NativePlace.setValue(resp[3].native)
        this.contact4.controls.SettledPlace.setValue(resp[3].settled)
        this.contact4.controls.ContactAddress.setValue(resp[3].contactAddress)
        this.contact4.controls.PerminentAddress.setValue(resp[3].permanentAddress)

        this.family5.controls.FatherName.setValue(resp[4].fathername)
        this.family5.controls.MotherName.setValue(resp[4].mothername)
        this.family5.controls.NoOfBrothers.setValue(resp[4].noofbrothers)
        this.family5.controls.NoOfBrotherUnmarried.setValue(resp[4].noofbrothersunmarrried)
        this.family5.controls.NoOfBrotherMarried.setValue(resp[4].noofbrothersmarrried)
        this.family5.controls.BrotherOccupation.setValue(resp[4].brotheroccupation)
        this.family5.controls.FathersOccupation.setValue(resp[4].fatheroccupation)
        this.family5.controls.MothersOccupation.setValue(resp[4].motheroccupation)
        this.family5.controls.NoOfSister.setValue(resp[4].noofsisters)
        this.family5.controls.NoOfSisterMarried.setValue(resp[4].noofsistersmarrried)
        this.family5.controls.NoOfSisterUnmarried.setValue(resp[4].noofsistersunmarrried)
        this.family5.controls.SisterOccupation.setValue(resp[4].sisteroccupation)

        this.partner6.controls.Religion.setValue(resp[5].religion)
        this.partner6.controls.Caste.setValue(resp[5].caste)
        this.partner6.controls.Star.setValue(resp[5].star)
        this.partner6.controls.Raasi.setValue(resp[5].raasi)
        this.partner6.controls.Gothram.setValue(resp[5].gothram)
        this.partner6.controls.MotherTongue.setValue(resp[5].motherTongue)

      })
    }
  }

  onSubmit() {
    this.submitted = true;
    if (this.personal1.invalid) {
      return;
    }

    let registration = {
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
    }

    if (!this.editBiodata) {
      this.apiService.createPersonalInfo(registration).subscribe(x => {
        this.divIndex = 2;
      });
    }
    else {
      this.apiService.updateRegistration(registration).subscribe(x => {
        this.divIndex = 2;
      });
    }
  }

  dateValidator(controlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      if (control.errors) {
        return;
      }
      else if (new Date(control.value) >= new Date('01/01/1990')) {
        control.setErrors({ dateValidatorshow: true });
      } else {
        control.setErrors(null);
      }
    }
  }

  onEducationSubmit() {
    this.submitted2 = true;
    if (this.education2.invalid) {
      return;
    }

    let education = {
      Heightqualification: this.education2.controls.EducationCategory.value,
      Graducation: this.education2.controls.EducationDetails.value,
      School: this.education2.controls.SchoolName.value,
      College: this.education2.controls.College.value,
    }

    if (!this.editBiodata) {
      this.apiService.createEducation(education).subscribe(x => {
        this.divIndex = 3;
      })
    }
    else {
      this.apiService.updateEducation(education).subscribe(x => {
        this.divIndex = 3;
      })
    }
  }

  onProfessionSubmit() {
    this.submitted3 = true;

    if (this.profession3.invalid) {
      return;
    }

    let profession = {
      Yearofstart: this.profession3.controls.WorkingSince.value,
      Joblocation: this.profession3.controls.PlaceofJob.value,
      Income: this.profession3.controls.AnnualIncome.value,
      Companydetails: this.profession3.controls.OccupationDetails.value,
      Jobtype: this.profession3.controls.Jobtype.value,
      Professiondetails: this.profession3.controls.OccupationDetails.value,
      Professiontype: this.profession3.controls.Occupation.value,
    }

    if (!this.editBiodata) {
      this.apiService.createProfessional(profession).subscribe(x => {
        this.divIndex = 4;
      })
    }
    else {
      this.apiService.updateProfessional(profession).subscribe(x => {
        this.divIndex = 4;
      })
    }
  }

  onContactSubmit() {
    this.submitted4 = true;

    if (this.contact4.invalid) {
      return;
    }

    let address = {
      ContactAddress: this.contact4.controls.ContactAddress.value,
      Visa: this.contact4.controls.VisaStatus.value,
      District: this.contact4.controls.CityLivingIn.value,
      State: this.contact4.controls.StateLivingIn.value,
      Country: this.contact4.controls.CountryLivingIn.value,
      Settled: this.contact4.controls.SettledPlace.value,
      Native: this.contact4.controls.NativePlace.value,
      PermanentAddress: this.contact4.controls.PerminentAddress.value,
    }

    if (!this.editBiodata) {
      this.apiService.createAddress(address).subscribe(x => {
        this.divIndex = 5;
      })
    }
    else {
      this.apiService.updateAddress(address).subscribe(x => {
        this.divIndex = 5;
      })
    }
  }

  onFamilySubmit() {
    this.submitted5 = true;

    if (this.family5.invalid) {
      return;
    }

    let family = {
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
    }

    if (!this.editBiodata) {
      this.apiService.createFamily(family).subscribe(x => {
        this.divIndex = 6;
      })
    }
    else {
      this.apiService.updateFamily(family).subscribe(x => {
        this.divIndex = 6;
      })
    }
  }

  onPartnerSubmit() {
    this.submitted6 = true;

    if (this.partner6.invalid) {
      return;
    }

    let partner = {
      Religion: this.partner6.controls.Religion.value,
      Caste: this.partner6.controls.Caste.value,
      Star: this.partner6.controls.Star.value,
      Raasi: this.partner6.controls.Raasi.value,
      Gothram: this.partner6.controls.Gothram.value,
      MotherTongue: this.partner6.controls.MotherTongue.value,
    }

    if (!this.editBiodata) {
      this.apiService.createReligious(partner).subscribe(x => {
        this.router.navigate(['/imageupload']);
      })
    }
    else {
      this.apiService.updateReligious(partner).subscribe(x => {
        this.router.navigate(['/imageupload']);
      })
    }
  }

  clickBack(e) {
    this.divIndex = e - 1;
  }

  stepperNext(index) {
    this.divIndex = index + 1;
  }
}
