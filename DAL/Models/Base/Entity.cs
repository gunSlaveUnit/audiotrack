using System.Text.Json.Serialization;
using DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Base;

public abstract class Entity : IEntity
{
    [BsonId]
    [BsonElement("id")]
    [JsonPropertyName("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}