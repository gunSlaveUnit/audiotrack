using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class ExaminationData
{
    [BsonElement("data")]
    [JsonPropertyName("data")]
    public Data Data { get; set; }
    
    [BsonElement("settings")]
    [JsonPropertyName("settings")]
    public Settings Settings { get; set; }
}
