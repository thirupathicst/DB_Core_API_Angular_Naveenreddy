import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { BiodataComponent } from './biodata/biodata.component';
import { SideLayoutComponent } from './side-layout/side-layout.component';
import { HeaderLayoutComponent } from './header-layout/header-layout.component';

import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { QuicksearchComponent } from './quicksearch/quicksearch.component';
import { SearchbycityComponent } from './searchbycity/searchbycity.component';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { PartnerinformationComponent } from './partnerinformation/partnerinformation.component';
import { SearchbynameComponent } from './searchbyname/searchbyname.component';
import { SearchbyprofileComponent } from './searchbyprofile/searchbyprofile.component';
import { ImageuploadComponent } from './imageupload/imageupload.component';
import { AddstoryComponent } from './addstory/addstory.component';
import { LoaderInterceptor } from './loader-interceptor.service';
import { APIServiceService } from './apiservice.service';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    BiodataComponent,
    SideLayoutComponent,
    HeaderLayoutComponent,
    ForgotpasswordComponent,
    QuicksearchComponent,
    SearchbycityComponent,
    ChangepasswordComponent,
    PartnerinformationComponent,
    SearchbynameComponent,
    SearchbyprofileComponent,
    ImageuploadComponent,
    AddstoryComponent,
    PagenotfoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MDBBootstrapModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    APIServiceService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }

