using System.Text.Json.Serialization;
using DAL.Models.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class TestStatus : Entity
{
    [BsonElement("status")]
    [JsonPropertyName("status")]
    public string Name { get; set; }
}

public static class PossibleTestStatuses
{
    public enum Codes
    {
        FAILED, 
        PASSED,
        UNKNOWN,
        NOISY
    }

    public static readonly List<string> TextRepresentation = new List<string>()
    {
        "Failed", 
        "Passed", 
        "Result unknown",
        "Noise in the data"
    };
}