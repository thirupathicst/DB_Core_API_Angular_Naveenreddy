import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../Services/apiservice.service';

@Component({
  selector: 'app-searchbycity',
  templateUrl: './searchbycity.component.html',
  styleUrls: ['./searchbycity.component.css']
})
export class SearchbycityComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,private apiService: APIServiceService) { }
  table:any= [];
  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      Cityname: ['', Validators.required],
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }
    this.apiService.searchTerm('',this.validatingForm.controls.Cityname.value).subscribe(x => {
      this.table=x;
    })
  }
}
