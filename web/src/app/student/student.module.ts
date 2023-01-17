import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentRoutingModule } from './student-routing.module';
import { StudentComponent } from './student/student.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [StudentComponent ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
  ]
})
export class StudentModule { }
