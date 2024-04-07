using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class Device : Entity
{
    [BsonElement("serial_number")]
    [JsonPropertyName("serial_number")]
    public string SerialNumber { get; set; }
    
    [BsonElement("token")]
    [JsonPropertyName("token")]
    public string AccessToken { get; set; }
    
    [BsonElement("region")]
    [JsonPropertyName("region")]
    public string Region { get; set; }
    
    [BsonElement("institution")]
    [JsonPropertyName("institution")]
    public string Institution { get; set; }
}