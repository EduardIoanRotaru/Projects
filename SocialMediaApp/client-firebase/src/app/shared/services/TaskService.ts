import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { AngularFirestoreCollection } from '@angular/fire/compat/firestore';
import { ITask } from '../models/ITask';

@Injectable({
	providedIn: 'root'
})
export class TaskService {
	tasksCollection: AngularFirestoreCollection<ITask[]>;
	tasksLists: Observable<any>;

	constructor(private readonly af: AngularFirestore) {
		this.tasksCollection = this.af.collection<ITask[]>('Task');
		this.tasksLists = this.tasksCollection.snapshotChanges().pipe(
			map((fireData) =>
				fireData.map((f) => {
					const data = f.payload.doc.data() as ITask[];
					const id = f.payload.doc.id;

					return { id, ...data };
				})
			)
		);
	}

	getFeedPost() {
		return this.tasksLists;
	}

	addFeedPost(task: any) {
		return this.tasksCollection.add(task);
	}

	deleteTask(id: any) {
		return this.tasksCollection.doc(id).delete();
	}

	updateTask(task: any) {
		return this.tasksCollection.doc(task.id).update(task);
	}
}
