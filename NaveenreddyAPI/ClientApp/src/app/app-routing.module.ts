import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddstoryComponent } from './addstory/addstory.component';
import { BiodataComponent } from './biodata/biodata.component';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { ForgotpasswordComponent } from './forgotpassword/forgotpassword.component';
import { ImageuploadComponent } from './imageupload/imageupload.component';
import { LoginComponent } from './login/login.component';
import { PartnerinformationComponent } from './partnerinformation/partnerinformation.component';
import { QuicksearchComponent } from './quicksearch/quicksearch.component';
import { RegistrationComponent } from './registration/registration.component';
import { SearchbycityComponent } from './searchbycity/searchbycity.component';
import { SearchbynameComponent } from './searchbyname/searchbyname.component';
import { SearchbyprofileComponent } from './searchbyprofile/searchbyprofile.component';
import { SideLayoutComponent } from './side-layout/side-layout.component';

const routes: Routes = [
  {
    path: '', component: SideLayoutComponent, children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'biodata', component: BiodataComponent},
      { path: 'forgotpassword', component: ForgotpasswordComponent },
      { path: 'quicksearch', component: QuicksearchComponent },
      { path: 'changepassword', component: ChangepasswordComponent },
      { path: 'partnerinfo', component: PartnerinformationComponent },
      { path: 'searchbycity', component: SearchbycityComponent },
      { path: 'searchbyname', component: SearchbynameComponent },
      { path: 'searchbyprofile', component: SearchbyprofileComponent },
      { path: 'imageupload', component: ImageuploadComponent },
      { path: 'story', component: AddstoryComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
