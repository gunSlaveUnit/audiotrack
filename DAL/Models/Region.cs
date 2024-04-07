using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class Region : Entity
{
    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
}