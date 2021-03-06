import { Component } from '@angular/core';
import { APIServiceService } from './Services/apiservice.service';

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
      //this.loading = v;
      setTimeout(() => {
        this.loading = v;
      }, 0);
    })
  }
}
