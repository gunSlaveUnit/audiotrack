using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Patient;

public class Sex : Entity
{
    [BsonElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }
    
    [BsonElement("sex")]
    [JsonPropertyName("sex")]
    public string Name { get; set; }
}

public static class PossiblePatientSexes
{
    public enum Codes
    {
        MALE,
        FEMALE,
        UNKNOWN
    }
}