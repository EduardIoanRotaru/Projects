import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, noop, tap } from 'rxjs';
import { ISearchResponse } from '../models/dtos/ISearchProjectResponse';
import { ITask } from '../models/ITask';
import { TaskInactiveDto } from '../models/temporary-objects/TaskInactiveDto';
import { TasksGroup } from '../models/temporary-objects/TasksGroup';
import { TaskToCompleteDto } from '../models/temporary-objects/TaskToCompleteDto';
import { TaskTrashDto } from '../models/temporary-objects/TaskTrashDto';
@Injectable({
  providedIn: 'root',
})
export class UpcomingTasksService {
  url: string = 'https://localhost:7284/api/task/';
  result = [];
  constructor(private http: HttpClient) { }

  getUpcomingTasks() {
    return this.http.get<any>(this.url);
  }

  getTaskById(id: number) {
    return this.http.get<any>(`${this.url}${id}`);
  }

  getAllTasksOrderedByDateAscending() {
    return this.http.get<TasksGroup[]>(this.url + 'getAllOrderedByDateAscending');
  }

  getAllTasksOrderedByDateDescending() {
    return this.http.get<any>(this.url + 'getAllOrderedByDateDescending');
  }

  getAllTasksOrderedByLabel() {
    return this.http.get<any>(this.url + 'getAllTasksOrderedByLabel');
  }

  getAllTasksOrderedByDateAndNotcompleted() {
    return this.http.get<any>(
      this.url + 'getAllTasksOrderedByDateAndNotcompleted'
    );
  }

  addOrUpdate(task: ITask) {
    return this.http.post<any>(this.url + 'addOrUpdate', task);
  }

  deleteTask(id: number) {
    return this.http.delete(this.url + id);
  }

  markTaskAsCompleted(taskToCompleteDto: TaskToCompleteDto) {
    return this.http.post(this.url + 'markTaskAsCompleted', taskToCompleteDto);
  }

  markTaskAsInactive(taskInactiveDto: TaskInactiveDto) {
    return this.http.post(this.url + 'markTaskAsInactive', taskInactiveDto);
  }

  moveTaskToTrash(taskTrashDto: TaskTrashDto) {
    return this.http.post(this.url + 'moveTaskToTrash', taskTrashDto);
  }

  moveMultipleTasksToTrash(taskIds: number[], projectId: number) {
    return this.http.put(this.url + `removeTasksFromProject/${projectId}`, taskIds);
  }

  getTasksToAssign(query: string, projectId: number) {
    return this.http.get<ISearchResponse>(
      this.url + 'searchTasks', {
      params: { searchText: query, projectId: projectId }
    }).pipe(
      map((data: ISearchResponse) => (data && data.items || [])),
      tap(() => noop, err => {
        // in case of http error
        return err && err.message || 'Something goes wrong';
      })
    );
  }

  assignUserToTask(taskId: number, userId: number) {
    return this.http.post<any>(this.url + `addUserToTask/${taskId}/${userId}`, {});
  }

  removeMultipleTasksFromProject(projectId: number, taskIds: number[]) {
    return this.http.post<any>(`https://localhost:7284/api/task` + `/removeTasksFromProject/${projectId}`, taskIds);
  }

  getInactiveTasks(projectId: number) {
    return this.http.get<ITask[]>(this.url + `inactiveTasks/${projectId}`);
  }

  makeMultipleTasksInactive(projectId: number, tasksIds: number[]) {
    return this.http.put<any>(`https://localhost:7284/api/task` + `/markTasksInactive/${projectId}`, tasksIds);
  }
}


