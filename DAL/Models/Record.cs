using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class Record : Entity
{
    [BsonElement("date")]
    [JsonPropertyName("date")]
    public DateTime DateChange { get; set; }
    
    [BsonElement("patient")]
    [JsonPropertyName("patient")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Patient { get; set; }
    
    [BsonElement("user")]
    [JsonPropertyName("user")]
    [BsonIgnoreIfNull]
    public string? User { get; set; }
    
    [BsonElement("new_status")]
    [JsonPropertyName("new_status")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string NewStatus { get; set; }
}