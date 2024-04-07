import {Entity} from "./Entity";

export class Sex extends Entity {
    sex: string
    code: number

    constructor(id: string, sex: string, code: number) {
        super(id)
        this.sex = sex
        this.code = code
    }
}
