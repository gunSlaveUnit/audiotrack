import {Entity} from "./Entity";

export class MedicalInstitution extends Entity {
    name: string
    region: string

    constructor(id: string, name: string, region: string) {
        super(id);
        this.name = name;
        this.region = region;
    }
}