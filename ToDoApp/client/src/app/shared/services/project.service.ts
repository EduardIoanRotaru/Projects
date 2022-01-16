import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

	url: string = 'https://localhost:7284/api/task/';

  constructor(private http: HttpClient) { }

  getProjects() {

  }

  getProjectById(taskId: number) {

  }

  addProject() {}

  editProject() {}

  deleteProject() {}
}
