import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IComment } from 'src/app/shared/models/IComment';
import { ITodayTask } from 'src/app/shared/models/ITodayTasks';
import { TaskService } from 'src/app/shared/services/task.service';
import { OurToastrService } from 'src/app/shared/services/toastr.service';
@Component({
  selector: 'app-today-tasks-comments',
  templateUrl: './today-tasks-comments.component.html',
  styleUrls: ['./today-tasks-comments.component.scss']
})
export class TodayTasksCommentsComponent implements OnInit {
  @Input() taskObj: {tasks: ITodayTask[], index: number};
  @Output() closeTaskCommentSection: EventEmitter<number> = new EventEmitter();

  commentForm: FormGroup;
  commentFormInitial: FormGroup;
  editMode: boolean;
  commentIndex: number;

  constructor(private fb: FormBuilder, private taskService: TaskService, private toastrService: OurToastrService) { }

  ngOnInit(): void {
    this.createForm();
  }

  get commentText() {
		return this.commentForm.get('commentText');
	}

  onSubmit() {
		this.taskObj.tasks[this.taskObj.index].comments
        .push(this.commentForm.value);

		this.taskService.updateTodayTask(this.taskObj.tasks).subscribe(result => {
			this.editMode = false;
			this.commentForm.reset(this.commentFormInitial);
			this.toastrService.showSuccess(result);
		});
  }
 
  removeCommentFromTask(index: number) {
    this.taskObj.tasks[this.taskObj.index].comments.splice(index, 1);
    this.taskService.updateTodayTask(this.taskObj.tasks);
  }

  enableEditComment(index: number) {
		this.editMode = true;
		this.commentIndex = index;
		this.patchForm(this.taskObj.tasks[this.taskObj.index].comments[index]);
	}

	cancelEditMode() {
		this.editMode = false;
    this.commentForm.reset(this.commentFormInitial);
	}

  cancelAddComment() {
    this.closeTaskCommentSection.emit(this.taskObj.index);
  }

	editComment() {
		this.taskObj.tasks[this.taskObj.index].comments[this.commentIndex] = this.commentForm.value;
		this.taskService.updateTodayTask(this.taskObj.tasks).subscribe(result => {
			this.editMode = false;
			this.commentForm.reset(this.commentFormInitial);
			this.toastrService.showSuccess(result);
		});
	}

  private patchForm(comment: IComment) {
		this.commentForm.patchValue(comment);
	}

  private createForm() {
    this.commentForm = this.fb.group({
      commentText: ['', [Validators.required, Validators.minLength(3)]],
    });

    this.commentFormInitial = this.commentForm.value;
  }
}
