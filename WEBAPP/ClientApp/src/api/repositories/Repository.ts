import {IRepository} from "../interfaces/IRepository";
import {Region} from "../models/Region";
import {Patient} from "../models/Patient";
import {Device} from "../models/Device";
import {Code} from "../models/Code";
import {PatientStatus} from "../models/PatientStatus";
import {Sex} from "../models/Sex";
import {Record} from "../models/Record";
import {BASE_URL} from "../constants/Constants";
import {MedicalInstitution} from "../models/MedicalInstitution";

abstract class Repository<T> implements IRepository<T> {
    baseUrl: string = BASE_URL;
    collection: string;

    protected constructor(collection: string) {
        this.collection = collection + "/";
    }

    GetAsync(): Promise<T[]> {
        return fetch(this.baseUrl+this.collection)
            .then(r => r.json());
    }
    
    GetItemAsync(id: string): Promise<T> {
        return fetch(this.baseUrl+this.collection+id)
            .then(r => r.json());
    }

    UpdateAsync(id: string, e: T): Promise<void> {
        return fetch(this.baseUrl+this.collection+id, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(e),
            credentials: "include"
        }).then(_ => {});
    }
    
    DeleteAsync(id: string): Promise<void> {
        return fetch(this.baseUrl+this.collection+id, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json"
            },
            credentials: "include"
        }).then(_ => {});
    }
}

export class RegionsRepository extends Repository<Region> {
    constructor(collection: string) {
        super(collection);
    }
}

export class PatientsRepository extends Repository<Patient> {
    constructor(collection: string) {
        super(collection);
    }
}

export class PatientStatusesRepository extends Repository<PatientStatus> {
    constructor(collection: string) {
        super(collection);
    }
}

export class PatientSexesRepository extends Repository<Sex> {
    constructor(collection: string) {
        super(collection);
    }
}

class PreLinkInfo {
    region: string
    institution: string
    
    constructor(region: string, institution: string) {
        this.region = region
        this.institution = institution
    }
}

export class DevicesRepository extends Repository<Device> {
    constructor(collection: string) {
        super(collection);
    }

    GetCode(info: PreLinkInfo): Promise<Code> {
        return fetch(this.baseUrl+this.collection+"prelink", {
            method: "POST",
            body: JSON.stringify(info),
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(r => r.json());
    }
}

export class HistoryRepository extends Repository<Record> {
    constructor(collection: string) {
        super(collection);
    }
    
    GetHistoryForPatient(patientId: string) : Promise<Record[]> {
        return fetch(this.baseUrl+this.collection+`patient/${patientId}`).then(r => r.json())
    }
}

export class MedicalInstitutionsRepository extends Repository<MedicalInstitution> {
    constructor(collection: string) {
        super(collection);
    }
    
    GetAsyncByRegion(regionId: string) : Promise<MedicalInstitution[]> {
        return fetch(this.baseUrl+this.collection+`region/${regionId}`).then(r => r.json())
    }
}
