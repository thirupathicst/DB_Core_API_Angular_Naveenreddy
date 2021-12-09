import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../apiservice.service';

@Component({
  selector: 'app-addstory',
  templateUrl: './addstory.component.html',
  styleUrls: ['./addstory.component.css']
})
export class AddstoryComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required],
      MarriageDate: ['', Validators.required],
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.validatingForm.invalid) {
      return;
    }

    var _story = {
      Name: this.validatingForm.controls.Name.value,
      Description: this.validatingForm.controls.Description.value,
      MarriageDate: this.validatingForm.controls.MarriageDate.value,
      PersonId: localStorage.getItem('isPersonId')
    }

    this.apiService.addStory(_story).subscribe(x => {
      console.log(x);
    }, err => {
      console.log(err);
    });
  }

}
