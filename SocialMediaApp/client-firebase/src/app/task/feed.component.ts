import { Component, OnInit } from '@angular/core';
import { ITask as IFeedPost } from '../shared/models/ITask';
import { TaskService as FeedService } from '../shared/services/TaskService';

@Component({
	selector: 'app-feed',
	templateUrl: './feed.component.html',
	styleUrls: [ './feed.component.scss' ]
})
export class FeedComponent implements OnInit {
	feedPost: IFeedPost = {
		id: 'sadsadas',
		name: 'Clean toilet'
	};

	posts: IFeedPost[] = [];

	constructor(private feedService: FeedService) {}

	ngOnInit(): void {
    	this.getFeedPost();
 	}

	 addFeedPost() {
		this.feedService.addFeedPost(this.feedPost);
	}

	private getFeedPost() {
		this.feedService.getFeedPost().subscribe((t) => {
			this.posts = t;
		});
	}
}

