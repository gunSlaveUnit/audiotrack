import {Entity} from "./Entity";

export class PatientStatus extends Entity {
    status: string
    code: number

    constructor(id: string, status: string, code: number) {
        super(id)
        this.status = status
        this.code = code
    }
}
