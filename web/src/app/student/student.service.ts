import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }
  getStudents(): Observable<Student[]> {
    const url = this.baseUrl + 'students';
    return this.http.get<Student[]>(url);
  }
  deleteStudent(id: number): Observable<DeleteStudentResponse> {
    const url = this.baseUrl + `students/${id}`;
    return this.http.delete<DeleteStudentResponse>(url);
  }
  addStudent(student:CreateStudentRequest): Observable<CreateStudentResponse> {
    const url = this.baseUrl + 'students';
    return this.http.post<CreateStudentResponse>(url, student);
  }
}
export interface DeleteStudentResponse {
  status: boolean;
}

export interface CreateStudentResponse {
  status: boolean;
}

export interface CreateStudentRequest {
  firstName:	string;
  lastName:	string;
  email:	string;
  major:	string;
  averageGrade:number;
}
