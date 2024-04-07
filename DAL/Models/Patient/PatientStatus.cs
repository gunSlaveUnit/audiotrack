using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Patient;

public class PatientStatus : Entity
{
    [BsonElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }
    
    [BsonElement("status")]
    [JsonPropertyName("status")]
    public string Name { get; set; }
}

public static class PossiblePatientStatuses
{
    public enum Codes
    {
        NEEDS_SCREENING, 
        SCREENING_PASSED,
        NEEDS_APPOINTMENT_EXAMINATION,
        CONTACT_INFORMATION_REQUIRED,
        REGISTERED_EXAMINATION,
        EXAMINATION_COMPLETED_SUCCESSFULLY,
        NEEDS_IMPLANT,
        NEEDS_HEARING_AID,
        NEEDS_REHAB,
        REFUSAL
    }
}