using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Patient : Entity
{
    [BsonElement("lastname")]
    [JsonPropertyName("lastname")]
    public string Surname { get; set; }
    
    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [BsonElement("othername")]
    [JsonPropertyName("othername")]
    public string Patronymic { get; set; }
    
    [BsonElement("dateOfBirth")]
    [JsonPropertyName("dateOfBirth")]
    public DateTime BirthDay { get; set; }
    
    [BsonElement("sex")]
    [JsonPropertyName("sex")]
    public string Sex { get; set; }
    
    [BsonElement("status")]
    [JsonPropertyName("status")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Status { get; set; }
    
    [BsonElement("tests")]
    [JsonPropertyName("tests")]
    [BsonIgnoreIfNull]
    public IEnumerable<string> Tests { get; set; }
}