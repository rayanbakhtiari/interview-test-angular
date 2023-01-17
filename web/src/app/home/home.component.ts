import { StudentService } from './../student/student.service';
import { Component  } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';
import {take} from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent  {
  public students: Student[];
  constructor(private studentService: StudentService,public dialog: MatDialog ) {
    this.loadStudents();
  }
  openDialog(id: number): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      data: {title: "Delete Student", message: "Are you sure to delete Student"}
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result)
        this.studentService.deleteStudent(id).pipe(take(1)).subscribe(res => {
          this.loadStudents();
        });
    });
  }
  private loadStudents() {
    this.studentService.getStudents().pipe(take(1)).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

