using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class Examination
{
    [BsonElement("assistant")]
    [JsonPropertyName("assistant")]
    public string Assistant { get; set; }
    
    [BsonElement("bin1")]
    [JsonPropertyName("bin1")]
    [BsonIgnoreIfNull]
    public string? Bin1 { get; set; }
    
    [BsonElement("comment")]
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
    
    [BsonElement("datetime")]
    [JsonPropertyName("datetime")]
    public DateTime Time { get; set; }
    
    [BsonElement("department")]
    [JsonPropertyName("department")]
    public string Department { get; set; }
    
    [BsonElement("device")]
    [JsonPropertyName("device")]
    public string Device { get; set; }
    
    [BsonElement("ear")]
    [JsonPropertyName("ear")]
    public int Ear { get; set; }
    
    [BsonElement("examiner")]
    [JsonPropertyName("examiner")]
    public string Examiner { get; set; }
    
    [BsonElement("int1")]
    [JsonPropertyName("int1")]
    public int Int1 { get; set; }
    
    [BsonElement("int2")]
    [JsonPropertyName("int2")]
    public int Int2 { get; set; }
    
    [BsonElement("int3")]
    [JsonPropertyName("int3")]
    public int Int3 { get; set; }
    
    [BsonElement("int4")]
    [JsonPropertyName("int4")]
    public int Int4 { get; set; }
    
    [BsonElement("lastEditDate")]
    [JsonPropertyName("lastEditDate")]
    public DateTime LastEditTime { get; set; }
    
    [BsonElement("nurse")]
    [JsonPropertyName("nurse")]
    public string Nurse { get; set; }
    
    [BsonElement("real1")]
    [JsonPropertyName("real1")]
    public double Real1 { get; set; }
    
    [BsonElement("real2")]
    [JsonPropertyName("real2")]
    public double Real2 { get; set; }
    
    [BsonElement("real3")]
    [JsonPropertyName("real3")]
    public double Real3 { get; set; }
    
    [BsonElement("real4")]
    [JsonPropertyName("real4")]
    public double Real4 { get; set; }
    
    [BsonElement("result")]
    [JsonPropertyName("result")]
    public int Result { get; set; }
    
    [BsonElement("tags")]
    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    [BsonElement("text1")]
    [JsonPropertyName("text1")]
    [BsonIgnoreIfNull]
    public string? Text1 { get; set; }

    [BsonElement("text2")]
    [JsonPropertyName("text2")]
    [BsonIgnoreIfNull]
    public string? Text2 { get; set; }
    
    [BsonElement("type")]
    [JsonPropertyName("type")]
    public int Type { get; set; }
    
    [BsonElement("data")]
    [JsonPropertyName("data")]
    public ExaminationData ExaminationData { get; set; }
}