import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { APIServiceService } from '../apiservice.service';

@Component({
  selector: 'app-imageupload',
  templateUrl: './imageupload.component.html',
  styleUrls: ['./imageupload.component.css']
})
export class ImageuploadComponent implements OnInit {
  validatingForm: FormGroup;
  submitted = false;
  uploadImg1: File;
  filePath1: string;
  filePath2: string;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      upload1: ['', Validators.required],
      upload2: ['', Validators.required],
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    //this.uploadImg = {
    //  file1: this.validatingForm.controls.upload1.value,
    //  file2: this.validatingForm.controls.upload2.value
    //}
    this.apiService.uploadImages(this.uploadImg1).subscribe(x => {
      //alert(this.login);
      console.log(x);
    }, err => {
      console.log(err)
    })
  }

  imagePreview(e, id) {
    const file = (e.target as HTMLInputElement).files[0];
    const reader = new FileReader();
    reader.onload = () => {
      if (id == 0) {
        this.filePath1 = reader.result as string;
        this.uploadImg1 = file;
      }
      else {
        this.filePath2 = reader.result as string;
        //this.uploadImg.push(file);
      }
    }
    reader.readAsDataURL(file)
  }
}
