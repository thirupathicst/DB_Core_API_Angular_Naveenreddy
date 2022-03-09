import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../Services/apiservice.service';

@Component({
  selector: 'app-searchbyname',
  templateUrl: './searchbyname.component.html',
  styleUrls: ['./searchbyname.component.css']
})
export class SearchbynameComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,private apiService: APIServiceService) { }
  table:any= [];
  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      Name: ['', Validators.required],
    })
  }
  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    this.apiService.searchTerm(this.validatingForm.controls.Name.value).subscribe(x => {
      this.table=x;
    })
  }
}
