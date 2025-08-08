using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace TerrorIncidentAPI.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public DateTime Date { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IncidentType? Type { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SeverityLevel? Severity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponType? Weapon { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TargetType? Target { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public bool IsSuccessful { get; set; }
        public bool IsSuicide { get; set; }
        public Casualties? Casualties { get; set; }
        public Attacker? Attacker { get; set; }
        public string[]? Tags { get; set; }
        public string? Source { get; set; }
        public ConfidenceLevel? Confidence { get; set; }
        public DateTime LastUpdated { get; set; }
    }
    [Owned]
    public class Casualties
    {
        public int? Fatalities { get; set; }
        public int? Injuries { get; set; }
        public int? Total => (Fatalities ?? 0) + (Injuries ?? 0);
    }

    [Owned]
    public class Attacker
    {
        public string? PerpetratorGroup { get; set; }
        public int NumberOfPerpetrators { get; set; }
        public bool ClaimedResponsibility { get; set; }
        public string? Motive { get; set; }
    }


    public enum IncidentType
    {
        All,
        Islamic_Terrorism,
        Domestic_Terrorism,
        Left_Wing_Terrorism,
        Right_Wing_Terrorism,
        Separatist_Terrorism,
        Cyber_Terrorism,
        Environmental_Terrorism,
        Unknown,
    }

    public enum SeverityLevel
    {
        Low,
        Medium,
        High,
        Critical,
    }

    public enum WeaponType
    {
        Explosives,
        Firearms,
        Knives,
        Vehicle,
        Chemical,
        Biological,
        Cyber,
        Arson,
        Other,
        Unknown,
    }

    public enum TargetType
    {
        Civilians,
        Government,
        Military,
        Police,
        Infrastructure,
        Transportation,
        Religious,
        Educational,
        Commercial,
        Media,
        Other,
        Unknown,
    }

    public enum ConfidenceLevel
    {
        Low,
        Medium,
        High,
        Verified,
    }
}
