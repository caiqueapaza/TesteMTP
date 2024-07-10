import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Task } from '../models/Task';
import { Response } from '../models/Response';
import { Observable, take } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = `${environment.ApiUrl}/Task`

  constructor(private http: HttpClient) {}

  GetTasks() : Observable<Response<Task[]>> {
    return this.http.get<Response<Task[]>>(this.apiUrl);
  }

  CreateTask(task : Task) : Observable<Response<Task[]>> {
    return this.http.post<Response<Task[]>>(`${this.apiUrl}`, task);
  }
}
