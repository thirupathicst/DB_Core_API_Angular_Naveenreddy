import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-side-layout',
  templateUrl: './side-layout.component.html',
  styleUrls: ['./side-layout.component.css']
})
export class SideLayoutComponent implements OnInit {
  constructor(private auth: AuthService) { }

  signOutvisible: boolean= false;
  ngOnInit(): void {
   this.signOutvisible=this.auth.checkToken();
  }

}
