export interface IProfile {
    token: string;
    expiration: string;
    claims?: IClaim[];
    currentUser?: IUser;
}

export interface IClaim {
    type: string;
    value: string;
}

export interface IUser {
    id?: number;
    userName?: string;
    email?: string;
    programCode: number;
    configId: number;
    roleId: number;
    programName: string;
    locationName: string;
}