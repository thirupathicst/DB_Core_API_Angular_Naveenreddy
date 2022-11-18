import { Component, OnInit,OnDestroy } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../Services/apiservice.service';
import { MDBModalService, ModalOptions } from 'angular-bootstrap-md';
import { InvitationComponent } from '../invitation/invitation.component';
import { DatashareService } from '../Services/datashare.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-searchbyname',
  templateUrl: './searchbyname.component.html',
  styleUrls: ['./searchbyname.component.css']
})
export class SearchbynameComponent implements OnInit,OnDestroy {
  validatingForm: FormGroup;
  submitted = false;
  table: any = [];
  moldeloptions= ModalOptions;

  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService, private modalService: MDBModalService, private datashare: DatashareService, private notification: NotificationService) { }
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
      if (x.length == 0) {
        this.notification.showInfo("No search result found, try with different keys !");
      }
      else
        this.table = x;
    })
  }

  childModel(name, id) {
    let obj = {
      "name": name,
      "id": id
    }
    this.datashare.changeName(obj);
    this.modalService.show(InvitationComponent);
  }

  ngOnDestroy(): void { 
    this.datashare.changeName('');
  }
}
