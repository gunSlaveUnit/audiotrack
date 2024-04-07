import {Entity} from "./Entity";

export class Patient extends Entity {
    lastname: string
    name: string
    othername: string
    dateOfBirth: Date
    sex: string
    status: string

    constructor(id: string, lastname: string, name: string, othername: string, dateOfBirth: Date, sex: string, status: string) {
        super(id)
        this.lastname = lastname
        this.name = name
        this.othername = othername
        this.dateOfBirth = dateOfBirth
        this.sex = sex
        this.status = status
    }
}
