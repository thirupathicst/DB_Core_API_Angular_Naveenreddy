import { Component, OnInit} from '@angular/core';
import { APIServiceService } from '../Services/apiservice.service';
import { DatashareService } from '../Services/datashare.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.css']
})
export class InvitationComponent implements OnInit {
  Message: string = "";
  Name: string = "";
  Id: Number;
  showDiv: boolean = true;
  grid: any = [];
  constructor(private apiService: APIServiceService, private notification: NotificationService, private datashare: DatashareService) { }
  ngOnInit(): void {
    this.datashare.name.pipe().subscribe(data => {
      this.Name = data.name;
      this.Id = data.id;
      this.showDiv = false;
    });

    if (this.Name == "" || this.Name == undefined) {
      this.apiService.getInvitation().subscribe(resp => {
        this.grid = resp
        if (this.grid.length > 0) {
          this.showDiv = false;
        }
      });
    }
  }

  onSubmit() {
    var inv = {
      "acceptedstatus": 0,
      "message": this.Message,
      "sentto": this.Id,
    }
    this.apiService.createInvitation(inv).subscribe(resp => {
      this.notification.showSuccess('Saved successfully.');
    });
  }

  accept(status:string,InvId:number)
  {
    var inv;
    if (status == 'a')
    {
      inv = {
        "acceptedstatus": 1,
        "invitationId":InvId
      }
    }
    else {
      inv = {
        "acceptedstatus": 2,
        "invitationId":InvId
      }
    }
    this.apiService.updateInvitation(inv).subscribe(resp => {
      this.notification.showSuccess('Record updated successfully.');
    });
  }
}
