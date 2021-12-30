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
  uploadImg: File[]=[];
  filePath1: string;
  filePath2: string;
  imageResp:any;
  constructor(private formBuilder: FormBuilder, private apiService: APIServiceService) { }

  ngOnInit(): void {
    this.validatingForm = this.formBuilder.group({
      upload1: ['', Validators.required],
      upload2: ['', Validators.required],
    })
  }

  ngAfterViewInit(): void {
    this.apiService.getImages().subscribe(resp => {
      this.imageResp=resp
    })
  }

  onloadImages(){
    this.apiService.getImages().subscribe(resp => {
      this.imageResp=resp
    })
  }

  get f() { return this.validatingForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.validatingForm.invalid) {
      return;
    }

    this.apiService.uploadImages(this.uploadImg).subscribe(x => {
      window.location.reload()
    })
  }

  imagePreview(e, id) {
    const file = (e.target as HTMLInputElement).files[0];
    
    const ext = file.name.match(/\.(.+)$/)[1];
    if (ext.toLowerCase() === 'jpg' || ext.toLowerCase() === 'jpeg' || ext.toLowerCase() === 'png') {
      const reader = new FileReader();
      reader.onload = () => {
        if (id == 0) {
          this.filePath1 = reader.result as string;
          this.uploadImg.push(file);
        }
        else {
          this.filePath2 = reader.result as string;
          this.uploadImg.push(file);
        }
      }
      reader.readAsDataURL(file)
      
    }
    else {
      if (id == 0) {
        this.validatingForm.controls.upload1.reset();
      }
      else if (id == 1) {
        this.validatingForm.controls.upload2.reset();
      }
      alert("Invalid File Format");
    }
  }
}
