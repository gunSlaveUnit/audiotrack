using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class DeviceLinkInfo : Entity
{
    [BsonElement("code")]
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    [BsonElement("region")]
    [JsonPropertyName("region")]
    public string Region { get; set; }
    
    [BsonElement("institution")]
    [JsonPropertyName("institution")]
    public string Institution { get; set; }
}