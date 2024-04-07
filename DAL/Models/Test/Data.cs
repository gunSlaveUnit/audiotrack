using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class Data
{
    [BsonElement("TIME_SEC_VALUES")]
    [JsonPropertyName("TIME_SEC_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? TimeValues { get; set; }
    
    [BsonElement("PROBABILITY_VALUES")]
    [JsonPropertyName("PROBABILITY_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? ProbabilityValues { get; set; }
    
    [BsonElement("SWEEP_SAMPLES")]
    [JsonPropertyName("SWEEP_SAMPLES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? SweepSamples { get; set; }
    
    [BsonElement("ZP_VALUE")]
    [JsonPropertyName("ZP_VALUE")]
    [BsonIgnoreIfNull]
    public double? ZPValue { get; set; }
    
    [BsonElement("ZM_VALUE")]
    [JsonPropertyName("ZM_VALUE")]
    [BsonIgnoreIfNull]
    public double? ZMValue { get; set; }
    
    [BsonElement("ZG_VALUE")]
    [JsonPropertyName("ZG_VALUE")]
    [BsonIgnoreIfNull]
    public double? ZGValue { get; set; }
    
    [BsonElement("AMP")]
    [JsonPropertyName("AMP")]
    [BsonIgnoreIfNull]
    public double? AMP { get; set; }
    
    [BsonElement("RNL")]
    [JsonPropertyName("RNL")]
    [BsonIgnoreIfNull]
    public double? RNL { get; set; }
    
    [BsonElement("EPOCHS_REJECTED")]
    [JsonPropertyName("EPOCHS_REJECTED")]
    [BsonIgnoreIfNull]
    public int? EpochsRejected { get; set; }
    
    [BsonElement("VALUES_C")]
    [JsonPropertyName("VALUES_C")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? ValuesC { get; set; }
    
    [BsonElement("VALUES_S")]
    [JsonPropertyName("VALUES_S")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? ValuesS { get; set; }
    
    [BsonElement("DPC_DATA_4")]
    [JsonPropertyName("DPC_DATA_4")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCData4 { get; set; }
    
    [BsonElement("SIGNAL_VALUES")]
    [JsonPropertyName("SIGNAL_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? SignalValues { get; set; }
    
    [BsonElement("ARTIFACTS_BY_POINTS")]
    [JsonPropertyName("ARTIFACTS_BY_POINTS")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? ArtifactsByPoints { get; set; }
    
    [BsonElement("AMPF1_VALUES")]
    [JsonPropertyName("AMPF1_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? AMPF1Values { get; set; }
    
    [BsonElement("NOISE_VALUES")]
    [JsonPropertyName("NOISE_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? NoiseValues { get; set; }
    
    [BsonElement("DPC_DATA_7")]
    [JsonPropertyName("DPC_DATA_7")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCData7 { get; set; }
    
    [BsonElement("MIN_NOISE_LEVEL")]
    [JsonPropertyName("MIN_NOISE_LEVEL")]
    [BsonIgnoreIfNull]
    public int? MinNoiseLevel { get; set; }
    
    [BsonElement("DPC_DATA_8")]
    [JsonPropertyName("DPC_DATA_8")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCData8 { get; set; }
    
    [BsonElement("DPC_DATA_5")]
    [JsonPropertyName("DPC_DATA_5")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCData5 { get; set; }
    
    [BsonElement("CURVES_BY_POINTS")]
    [JsonPropertyName("CURVES_BY_POINTS")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? CurvesByPoints { get; set; }
    
    [BsonElement("AMPF2_VALUES")]
    [JsonPropertyName("AMPF2_VALUES")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? AMPF2Values { get; set; }
    
    [BsonElement("IMPULSES_BY_POINTS")]
    [JsonPropertyName("IMPULSES_BY_POINTS")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? ImpulsesByPoints { get; set; }
    
    [BsonElement("DPC_KEYS")]
    [JsonPropertyName("DPC_KEYS")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCKeys { get; set; }
    
    [BsonElement("DPC_DATA_x")]
    [JsonPropertyName("DPC_DATA_x")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? DPCDataX { get; set; }
    
    [BsonElement("PASSED_FLAGS")]
    [JsonPropertyName("PASSED_FLAGS")]
    [BsonIgnoreIfNull]
    public IEnumerable<bool>? PassedFlags { get; set; }
    
    [BsonElement("AB_AVERAGE")]
    [JsonPropertyName("AB_AVERAGE")]
    [BsonIgnoreIfNull]
    public double? ABAverage { get; set; }
    
    [BsonElement("AVERAGES_NUMBER")]
    [JsonPropertyName("AVERAGES_NUMBER")]
    [BsonIgnoreIfNull]
    public int? AveragesAmount { get; set; }
    
    [BsonElement("STIMUL_CURVE")]
    [JsonPropertyName("STIMUL_CURVE")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? StimulusCurve { get; set; }
    
    [BsonElement("STIMUL_STABILITY")]
    [JsonPropertyName("STIMUL_STABILITY")]
    [BsonIgnoreIfNull]
    public double? StimulusStability { get; set; }
    
    [BsonElement("SIGNAL_A")]
    [JsonPropertyName("SIGNAL_A")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? SignalA { get; set; }
    
    [BsonElement("SIGNAL_B")]
    [JsonPropertyName("SIGNAL_B")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? SignalB { get; set; }
    
    [BsonElement("SNR")]
    [JsonPropertyName("SNR")]
    [BsonIgnoreIfNull]
    public IEnumerable<double>? SNR { get; set; }
    
    [BsonElement("NOISE")]
    [JsonPropertyName("NOISE")]
    [BsonIgnoreIfNull]
    public double? Noise { get; set; }

    [BsonElement("STABILITY")]
    [JsonPropertyName("STABILITY")]
    [BsonIgnoreIfNull]
    public double? Stability { get; set; }
    
    [BsonElement("ARTIFACT_NUMBER")]
    [JsonPropertyName("ARTIFACT_NUMBER")]
    [BsonIgnoreIfNull]
    public int? ArtifactsAmount { get; set; }
    
    [BsonElement("REPRODUCIBILITY")]
    [JsonPropertyName("REPRODUCIBILITY")]
    [BsonIgnoreIfNull]
    public int? Reproducibility { get; set; }
}