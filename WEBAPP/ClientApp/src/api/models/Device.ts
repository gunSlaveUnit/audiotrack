import {Entity} from "./Entity";

export class Device extends Entity {
    serial_number: string
    region: string
    institution: string
    
    constructor(id: string, serial_number: string, region: string, institution: string) {
        super(id)
        
        this.serial_number = serial_number
        this.region = region
        this.institution = institution
    }
}
