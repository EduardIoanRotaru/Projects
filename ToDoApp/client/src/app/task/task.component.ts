import { Component, OnInit } from '@angular/core';
import { ITask } from '../shared/models/ITask';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent implements OnInit {

  tasks: ITask[] = [];
  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<ITask[]>("https://localhost:7284/tasks").subscribe(t => {
      this.tasks = t;
    })
  }

}
