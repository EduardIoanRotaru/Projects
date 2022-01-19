import { IComment } from "./IComment";
import { ITask } from "./ITask";

export interface ITodayTask extends ITask {
    timeAdded: number;

    comments: IComment[];
}