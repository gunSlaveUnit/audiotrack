using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models.Test;

public class Settings
{
    [BsonElement("FORMAT")]
    [JsonPropertyName("FORMAT")]
    [BsonIgnoreIfNull]
    public int? Format { get; set; }
    
    [BsonElement("SAMPLING_FREQ")]
    [JsonPropertyName("SAMPLING_FREQ")]
    [BsonIgnoreIfNull]
    public int? SamplingFrequency { get; set; }
    
    [BsonElement("STIM_RATE")]
    [JsonPropertyName("STIM_RATE")]
    [BsonIgnoreIfNull]
    public int? STIMRate { get; set; }
    
    [BsonElement("MAX_TIME")]
    [JsonPropertyName("MAX_TIME")]
    [BsonIgnoreIfNull]
    public int? MaxTime { get; set; }
    
    [BsonElement("INTENSITY_LEVEL")]
    [JsonPropertyName("INTENSITY_LEVEL")]
    [BsonIgnoreIfNull]
    public int? IntensityLevel { get; set; }
    
    [BsonElement("ELECTRODE_SCHEME")]
    [JsonPropertyName("ELECTRODE_SCHEME")]
    [BsonIgnoreIfNull]
    public int? ElectrodeScheme { get; set; }
    
    [BsonElement("STIM_TYPE")]
    [JsonPropertyName("STIM_TYPE")]
    [BsonIgnoreIfNull]
    public string? STIMType { get; set; }

    [BsonElement("SCHEME_TYPE")]
    [JsonPropertyName("SCHEME_TYPE")]
    [BsonIgnoreIfNull]
    public int? SchemeType { get; set; }
    
    [BsonElement("SCHEME")]
    [JsonPropertyName("SCHEME")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? Scheme { get; set; }
    
    [BsonElement("NUMBER_OF_POINTS")]
    [JsonPropertyName("NUMBER_OF_POINTS")]
    [BsonIgnoreIfNull]
    public int? PointsAmount { get; set; }
    
    [BsonElement("INDEXES_OF_F1")]
    [JsonPropertyName("INDEXES_OF_F1")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? IndexesF1 { get; set; }
    
    [BsonElement("INDEXES_OF_F2")]
    [JsonPropertyName("INDEXES_OF_F2")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? IndexesF2 { get; set; }
    
    [BsonElement("SCALE")]
    [JsonPropertyName("SCALE")]
    [BsonIgnoreIfNull]
    public double? Scale { get; set; }
    
    [BsonElement("SUCCESS_LEVEL")]
    [JsonPropertyName("SUCCESS_LEVEL")]
    [BsonIgnoreIfNull]
    public int? SuccessLevel { get; set; }
    
    [BsonElement("SUCCESS_POINTS")]
    [JsonPropertyName("SUCCESS_POINTS")]
    [BsonIgnoreIfNull]
    public int? SuccessPoints { get; set; }
    
    [BsonElement("PROBE_SENSITIVITY")]
    [JsonPropertyName("PROBE_SENSITIVITY")]
    [BsonIgnoreIfNull]
    public int? ProbeSensitivity { get; set; }
    
    [BsonElement("NOISE_LEVEL")]
    [JsonPropertyName("NOISE_LEVEL")]
    [BsonIgnoreIfNull]
    public int? NoiseLevel { get; set; }
    
    [BsonElement("SIZE_OF_SNR")]
    [JsonPropertyName("SIZE_OF_SNR")]
    [BsonIgnoreIfNull]
    public int? SNRSize { get; set; }
    
    [BsonElement("SCALE_SIGNAL")]
    [JsonPropertyName("SCALE_SIGNAL")]
    [BsonIgnoreIfNull]
    public double? ScaleSignal { get; set; }
    
    [BsonElement("SCALE_STIMUL")]
    [JsonPropertyName("SCALE_STIMUL")]
    [BsonIgnoreIfNull]
    public double? ScaleStimulus { get; set; }
    
    [BsonElement("CRITERIA_INDEX")]
    [JsonPropertyName("CRITERIA_INDEX")]
    [BsonIgnoreIfNull]
    public int? CriteriaIndex { get; set; }
    
    [BsonElement("EPOCH_POINTS")]
    [JsonPropertyName("EPOCH_POINTS")]
    [BsonIgnoreIfNull]
    public int? EpochPoints { get; set; }
    
    [BsonElement("SMART_MODE")]
    [JsonPropertyName("SMART_MODE")]
    [BsonIgnoreIfNull]
    public bool? SmartMode { get; set; }
    
    [BsonElement("FREQ_COUNT_INDEX")]
    [JsonPropertyName("FREQ_COUNT_INDEX")]
    [BsonIgnoreIfNull]
    public int? FrequencyCountIndex { get; set; }
    
    [BsonElement("GAIN_SCALE")]
    [JsonPropertyName("GAIN_SCALE")]
    [BsonIgnoreIfNull]
    public int? GainScale { get; set; }
    
    [BsonElement("PROBES")]
    [JsonPropertyName("PROBES")]
    [BsonIgnoreIfNull]
    public string? Probes { get; set; }
    
    [BsonElement("EVAL_PASS_REFER")]
    [JsonPropertyName("EVAL_PASS_REFER")]
    [BsonIgnoreIfNull]
    public bool? EvalPassRefer { get; set; }
    
    [BsonElement("PASS_MIN_PRESSURE")]
    [JsonPropertyName("PASS_MIN_PRESSURE")]
    [BsonIgnoreIfNull]
    public int? PassMinPressure { get; set; }
    
    [BsonElement("PASS_MAX_PRESSURE")]
    [JsonPropertyName("PASS_MAX_PRESSURE")]
    [BsonIgnoreIfNull]
    public int? PassMaxPressure { get; set; }
    
    [BsonElement("PASS_MIN_COMPLIANCE")]
    [JsonPropertyName("PASS_MIN_COMPLIANCE")]
    [BsonIgnoreIfNull]
    public double? PassMinCompliance { get; set; }
    
    [BsonElement("PASS_MAX_COMPLIANCE")]
    [JsonPropertyName("PASS_MAX_COMPLIANCE")]
    [BsonIgnoreIfNull]
    public double? PassMaxCompliance { get; set; }
    
    [BsonElement("INTENSITY")]
    [JsonPropertyName("INTENSITY")]
    [BsonIgnoreIfNull]
    public int? Intensity { get; set; }

    [BsonElement("STIM_DURATION")]
    [JsonPropertyName("STIM_DURATION")]
    [BsonIgnoreIfNull]
    public int? STIMDuration { get; set; }
    
    [BsonElement("BEFORE_STIM_DURATION")]
    [JsonPropertyName("BEFORE_STIM_DURATION")]
    [BsonIgnoreIfNull]
    public int? BeforeStimDuration { get; set; }
    
    [BsonElement("AFTER_STIM_DURATION")]
    [JsonPropertyName("AFTER_STIM_DURATION")]
    [BsonIgnoreIfNull]
    public int? AfterStimDuration { get; set; }
    
    [BsonElement("IS_IPSI")]
    [JsonPropertyName("IS_IPSI")]
    [BsonIgnoreIfNull]
    public bool? IsIPSI { get; set; }
    
    [BsonElement("PRESSURE")]
    [JsonPropertyName("PRESSURE")]
    [BsonIgnoreIfNull]
    public int? Pressure { get; set; }
    
    [BsonElement("AR_MODE")]
    [JsonPropertyName("AR_MODE")]
    [BsonIgnoreIfNull]
    public int? ARMode { get; set; }
    
    [BsonElement("AR_SCREENING_THRESHOLD")]
    [JsonPropertyName("AR_SCREENING_THRESHOLD")]
    [BsonIgnoreIfNull]
    public double? ARScreeningThreshold { get; set; }
    
    [BsonElement("AR_MANUAL_STEP")]
    [JsonPropertyName("AR_MANUAL_STEP")]
    [BsonIgnoreIfNull]
    public int? ARManualStep { get; set; }
    
    [BsonElement("AR_MANUAL_STEP_BEFORE_COUNT")]
    [JsonPropertyName("AR_MANUAL_STEP_BEFORE_COUNT")]
    [BsonIgnoreIfNull]
    public int? ARManualStepBeforeCount { get; set; }
    
    [BsonElement("AR_MANUAL_STEP_AFTER_COUNT")]
    [JsonPropertyName("AR_MANUAL_STEP_AFTER_COUNT")]
    [BsonIgnoreIfNull]
    public int? ARManualStepAfterCount { get; set; }
    
    [BsonElement("AR_STIM_TIME")]
    [JsonPropertyName("AR_STIM_TIME")]
    [BsonIgnoreIfNull]
    public int? ARStimTime { get; set; }
    
    [BsonElement("AR_START_INTENSITIES")]
    [JsonPropertyName("AR_START_INTENSITIES")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? ARStartIntensities { get; set; }
    
    [BsonElement("AR_STIM_SIDES")]
    [JsonPropertyName("AR_STIM_SIDES")]
    [BsonIgnoreIfNull]
    public IEnumerable<bool>? ARStimSides { get; set; }
    
    [BsonElement("AR_STIM_TYPES")]
    [JsonPropertyName("AR_STIM_TYPES")]
    [BsonIgnoreIfNull]
    public IEnumerable<string>? ARStimTypes { get; set; }
    
    [BsonElement("AR_PRESSURES")]
    [JsonPropertyName("AR_PRESSURES")]
    [BsonIgnoreIfNull]
    public IEnumerable<int>? ARPressures { get; set; }
}