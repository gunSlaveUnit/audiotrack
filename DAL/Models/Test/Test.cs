using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class Test : Entity
{
    [BsonElement("address")]
    [JsonPropertyName("address")]
    public string Address { get; set; }
    
    [BsonElement("firstname")]
    [JsonPropertyName("firstname")]
    public string Name { get; set; }

    [BsonElement("lastname")]
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }

    [BsonElement("othername")]
    [JsonPropertyName("othername")]
    public string Othername { get; set; }

    [BsonElement("dateOfBirth")]
    [JsonPropertyName("dateOfBirth")]
    public DateTime BirthDay { get; set; }
    
    [BsonElement("sex")]
    [JsonPropertyName("sex")]
    public int Sex { get; set; }

    [BsonElement("weight")]
    [JsonPropertyName("weight")]
    public float Weight { get; set; }

    [BsonElement("height")]
    [JsonPropertyName("height")]
    public float Height { get; set; }

    [BsonElement("email")]
    [JsonPropertyName("email")]
    [EmailAddress]
    public string Email { get; set; }

    [BsonElement("comment")]
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [BsonElement("examinations")]
    [JsonPropertyName("examinations")]
    public IEnumerable<Examination> Examinations { get; set; }

    [BsonElement("diagnosis")]
    [JsonPropertyName("diagnosis")]
    public string Diagnosis { get; set; }

    [BsonElement("bin1")]
    [JsonPropertyName("bin1")]
    [BsonIgnoreIfNull]
    public string? Bin1 { get; set; }

    [BsonElement("insurance")]
    [JsonPropertyName("insurance")]
    [BsonIgnoreIfNull]
    public string Insurance { get; set; }
    
    [BsonElement("int1")]
    [JsonPropertyName("int1")]
    public int Int1 { get; set; }
    
    [BsonElement("phones")]
    [JsonPropertyName("phones")]
    public string Phones { get; set; }
    
    [BsonElement("tags")]
    [JsonPropertyName("tags")]
    public string Tags { get; set; }
    
    [BsonElement("text1")]
    [JsonPropertyName("text1")]
    [BsonIgnoreIfNull]
    public string? Text1 { get; set; }
}
