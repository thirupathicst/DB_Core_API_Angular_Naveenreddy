import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header-layout',
  templateUrl: './header-layout.component.html',
  styleUrls: ['./header-layout.component.css']
})
export class HeaderLayoutComponent implements OnInit {
  
  constructor(private router: Router) { }

  ngOnInit(): void {
    
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
