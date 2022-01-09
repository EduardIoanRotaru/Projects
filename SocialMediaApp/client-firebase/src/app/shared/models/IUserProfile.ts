import { IBase } from "./IBase";
import { IImage } from "./IImage";

export interface IUserProfile extends IBase {
    dateJoined: Date;
    location: string;
    profileImage: IImage;

    // When Auth is implemented
    // followers 
    // friends
}