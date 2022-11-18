import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MDBModalService } from 'angular-bootstrap-md';
import { InvitationComponent } from '../invitation/invitation.component';
import { APIServiceService } from '../Services/apiservice.service';
import { DatashareService } from '../Services/datashare.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-searchbycity',
  templateUrl: './searchbycity.component.html',
  styleUrls: ['./searchbycity.component.css']
})
export class SearchbycityComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService, private modalService: MDBModalService, private datashare: DatashareService, private notification: NotificationService) { }
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
    this.apiService.searchTerm('', this.validatingForm.controls.Cityname.value).subscribe(x => {
      if (x.length==0) {
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
    this.modalService.show(InvitationComponent)
  }
}
