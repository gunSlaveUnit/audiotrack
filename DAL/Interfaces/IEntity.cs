using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Interfaces;

public interface IEntity
{
    [BsonId]
    [BsonElement("id")]
    [JsonPropertyName("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}