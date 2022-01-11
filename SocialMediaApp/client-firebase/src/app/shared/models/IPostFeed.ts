import { IBase } from "./IBase";

export interface IPostFeed {
    id: string;
    title: string;
    content: string;
    likeCount: number;
    dislikeCount: number;
}