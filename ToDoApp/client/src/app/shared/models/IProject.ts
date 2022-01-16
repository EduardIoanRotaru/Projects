import { IBase } from "./IBase";
import { ITask } from "./ITask";

export interface IProject extends IBase {
    description: string;
    
    tasks: ITask[];
}