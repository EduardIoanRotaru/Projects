import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Label } from 'src/app/shared/models/enums/label';
import { ITodayTask } from 'src/app/shared/models/ITodayTasks';
import { TaskService } from 'src/app/shared/services/task.service';
import { OurToastrService } from 'src/app/shared/services/toastr.service';
@Component({
	selector: 'app-today-tasks',
	templateUrl: './today-tasks.component.html',
	styleUrls: [ './today-tasks.component.scss' ]
})
export class TodayTasksComponent implements OnInit {
	taskForm: FormGroup;
	taskFormInitial: any;

	todayTask: ITodayTask;
	todayTasks: ITodayTask[] = [];

	editMode: boolean = false;
	editObj: { todayTask: ITodayTask; index: number } = {} as { todayTask: ITodayTask; index: number };

	priorityEnum = Label;
	keys: any[];

	// showCommentComponent: boolean = false;
	showCommentComponent: any[] = [];

	currentDate = new Date();

	constructor(private fb: FormBuilder, private taskService: TaskService, private toastrService: OurToastrService) {
		this.keys = Object.keys(this.priorityEnum).filter((f) => !isNaN(Number(f)));
	}

	ngOnInit(): void {
		this.createForm();
		this.initializeTodayTasks();
	}

	get name() {
		return this.taskForm.get('name');
	}

	get label() {
		return this.taskForm.get('label');
	}

	displayCommentsComponent(index: any) {
		this.showCommentComponent[index] = !this.showCommentComponent[index];
	}

	removeItem(index: number) {
		this.todayTasks.splice(index, 1);
		this.taskService.updateTodayTask(this.todayTasks);
	}

	onSubmit() {
		this.todayTask = this.taskForm.value;
		this.todayTask.timeAdded = new Date().getTime();
		this.todayTask.comments = [];

		this.taskService.addTodayTask(this.todayTask).subscribe(
			(result) => {
				this.toastrService.showSuccess(result);
			},
			(error) => {
				this.toastrService.showError(error);
			}
		);
	}

	enableEditTask(task: ITodayTask, index: number) {
		this.editMode = true;
		this.editObj.todayTask = task;
		this.editObj.index = index;
		this.patchForm(this.editObj.todayTask);
	}

	cancelEditMode() {
		this.editMode = false;
		this.taskForm.reset(this.taskFormInitial);
	}

	editTask() {
		this.todayTasks[this.editObj.index] = this.taskForm.value;
		this.taskService.updateTodayTask(this.todayTasks).subscribe((result) => {
			this.editMode = false;
			this.taskForm.reset(this.taskFormInitial);
			this.toastrService.showSuccess(result);
		});
	}

	private patchForm(task: ITodayTask) {
		this.taskForm.patchValue(task);
	}

	private createForm() {
		this.taskForm = this.fb.group({
			name: [ '', [ Validators.required, Validators.minLength(3)] ],
			label: [ '', [] ]
		});

		this.taskFormInitial = this.taskForm.value;
	}

	private initializeTodayTasks() {
		this.todayTasks = this.taskService.getTodayTasks();
	}
}

// edit, fill up the form
// remove all at certain hour
// hide display edit button
