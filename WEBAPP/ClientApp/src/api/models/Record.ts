import {Entity} from "./Entity";

export class Record extends Entity {
    date: string
    user: string
    new_status: string

    constructor(id: string, date: string, user: string, newStatus: string) {
        super(id);
        this.date = date;
        this.user = user;
        this.new_status = newStatus;
    }
}