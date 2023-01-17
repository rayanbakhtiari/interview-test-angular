import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  studentForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private http: HttpClient,@Inject('BASE_URL') private baseUrl: string,
             private router: Router) {
    this.createForm();
  }
  ngOnInit() {
  }
  createForm() {
    this.studentForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.compose([Validators.required,Validators.email])],
      major: ['', Validators.required],
      averageGrade: [undefined, Validators.required]
    });
  }
  save()
  {

    var student: CreateStudentRequest = this.studentForm.value;
    var url = this.baseUrl + 'students';
    this.http.post<CreateStudentResponse>(this.baseUrl + 'students',student).subscribe(result => {
      this.router.navigateByUrl("");
    });
    console.log("saved", this.studentForm.getRawValue());
  }

}
interface CreateStudentResponse {
  status: boolean;
}
interface CreateStudentRequest {
  firstName:	string;
  lastName:	string;
  email:	string;
  major:	string;
  averageGrade:number;
}

