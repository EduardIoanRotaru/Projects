import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITask } from '../models/ITask';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
	url: string = 'https://localhost:7284/api/task/';

  constructor(private http: HttpClient) { }

  getTodayTasks() {

  }

  getUpcomingTasks() {

  }

  addTask(task: ITask) {}

  editTask(task: ITask) {}

  deleteTask(taskId: number) {}




}
