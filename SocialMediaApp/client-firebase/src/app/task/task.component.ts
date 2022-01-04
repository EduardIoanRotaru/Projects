import { Component, OnInit } from '@angular/core';
import { ITask } from '../shared/models/ITask';
import { TaskService } from '../shared/services/TaskService';

@Component({
	selector: 'app-task',
	templateUrl: './task.component.html',
	styleUrls: [ './task.component.scss' ]
})
export class TaskComponent implements OnInit {
	testTask: ITask = {
		id: 'sadsadas',
		name: 'Clean toilet'
	};

	tasks: ITask[] = [];

	constructor(private taskService: TaskService) {}

	ngOnInit(): void {
    this.getTask();
  }

	 addTask() {
		this.taskService.addTask(this.testTask);
	}

	private getTask() {
		this.taskService.getTasks().subscribe((t) => {
      console.log(t);
			this.tasks = t;
		});
	}
}
