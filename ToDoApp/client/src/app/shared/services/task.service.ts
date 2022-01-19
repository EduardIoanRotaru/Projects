import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { ITask } from '../models/ITask';
import { ITodayTask } from '../models/ITodayTasks';

@Injectable({
	providedIn: 'root'
})
export class TaskService {
	url: string = 'https://localhost:7284/api/task/';
	items: any[] = [];

	constructor(private http: HttpClient) {
		this.getTodayTasks();
	}

	getTodayTasks() {
		this.items = JSON.parse(localStorage.getItem('todayTasks') || '[]');
		return this.items;
	}

	addTodayTask(todayTask: ITodayTask): Observable<string> {
		if (this.items.length > 10) return throwError(() => new Error('Maximum of tasks for today exceeded'));

		this.items.push(todayTask);
		localStorage.setItem('todayTasks', JSON.stringify(this.items));

		return of('Task Added');
	}

	updateTodayTask(newTodayTasks: ITodayTask[]): Observable<string> {
		localStorage.setItem('todayTasks', JSON.stringify(newTodayTasks)); 

		return of('Task edited successfully');
	}

	editTodayTasks() {}

	getUpcomingTasks() {}

	addTask(task: ITask) {}

	editTask(task: ITask) {}

	deleteTask(taskId: number) {}
}
