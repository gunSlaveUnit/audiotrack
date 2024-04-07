import {Entity} from "./Entity";

export class Code extends Entity {
    code: string
    region: string
    institution: string
    
    constructor(id: string, code: string, region: string, institution: string) {
        super(id)
        this.code = code
        this.region = region
        this.institution = institution
    }
}
