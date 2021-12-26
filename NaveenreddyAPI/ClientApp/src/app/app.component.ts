import { Component } from '@angular/core';
import { Alert } from 'selenium-webdriver';
import { APIServiceService } from './apiservice.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Naveenreddy';

  loading: boolean;
  constructor(private loaderService: APIServiceService) {
    this.loaderService.isLoading.subscribe((v) => {
      //console.log(v);
      this.loading = v;
    })
  }
}
