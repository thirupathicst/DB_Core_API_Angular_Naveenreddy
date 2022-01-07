import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Alert } from 'selenium-webdriver';
import { APIServiceService } from '../Services/apiservice.service';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-header-layout',
  templateUrl: './header-layout.component.html',
  styleUrls: ['./header-layout.component.css']
})
export class HeaderLayoutComponent implements OnInit {

  constructor(private router: Router, private auth: AuthService,private apiService:APIServiceService) { }

  ngOnInit(): void {
    
  }

  logout() {
    this.apiService.signOut().subscribe(resp=>{

    })
    this.auth.removeAuthentication();
    this.router.navigate(['/login']);
  }
}
