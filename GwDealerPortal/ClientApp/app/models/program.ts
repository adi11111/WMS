export class ProgramModel {
    constructor() {
        this.ProgramCode = -1;
        this.ProgramName = "";
        this.IUD = "";
    }
    ProgramCode: number;
    ProgramName: string;
    IUD: string;
}
export class PartsCategory {
    constructor() {
        this.PartsCategoryCode = -1;
        this.PartsCategoryName = "";
    }
    PartsCategoryCode: number;
    PartsCategoryName: string;
}