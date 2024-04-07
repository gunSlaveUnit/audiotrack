using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class MedicalInstitution : Entity
{
    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [BsonElement("region")]
    [JsonPropertyName("region")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Region { get; set; }
}