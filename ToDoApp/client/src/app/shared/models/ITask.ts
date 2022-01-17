import { Label } from "./enums/label";
import { IBase } from "./IBase";
import { IComment } from "./IComment";

export interface ITask extends IBase {
    dateToComplete: Date;

    comments: IComment[];
    label: Label;
}