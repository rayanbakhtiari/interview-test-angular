import { CreateStudentRequest, StudentService } from './../student.service';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  studentForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private studentService: StudentService,
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
    if (this.studentForm.valid) {
      var student: CreateStudentRequest = this.studentForm.value;
      this.studentService.addStudent(student).pipe(take(1)).subscribe(result => {
        this.router.navigateByUrl("");
      }, error => console.error(error));
      console.log("saved", this.studentForm.getRawValue());
    }
  }

}
interface CreateStudentResponse {
  status: boolean;
}

