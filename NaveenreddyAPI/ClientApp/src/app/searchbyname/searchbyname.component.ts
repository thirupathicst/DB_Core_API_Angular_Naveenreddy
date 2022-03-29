import { Component, OnInit,OnDestroy } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../Services/apiservice.service';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { InvitationComponent } from '../invitation/invitation.component';
import { DatashareService } from '../Services/datashare.service';

@Component({
  selector: 'app-searchbyname',
  templateUrl: './searchbyname.component.html',
  styleUrls: ['./searchbyname.component.css']
})
export class SearchbynameComponent implements OnInit,OnDestroy {
  validatingForm: FormGroup;
  submitted = false;
  modalRef: MDBModalRef | null = null;
  
  constructor(private formBuilder: FormBuilder,private apiService: APIServiceService,private modalService: MDBModalService,private datashare:DatashareService) { }
  table: any = [];
  //name: string;
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

    this.apiService.searchTerm(this.validatingForm.controls.Name.value,'').subscribe(x => {
      this.table=x;
    })
  }

  childModel(name, id) {
    let obj = {
      "name": name,
      "id": id
    }
    this.datashare.changeName(obj);
    this.modalRef = this.modalService.show(InvitationComponent)
  }

  ngOnDestroy(): void { 
    this.datashare.changeName('');
  }
}
