import {IEntity} from "../interfaces/IEntity";

export class Entity implements IEntity {
    id: string;
    
    constructor(id: string) {
        this.id = id;
    }
}