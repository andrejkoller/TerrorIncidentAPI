using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace TerrorIncidentAPI.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IncidentType? Type { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SeverityLevel? Severity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponType? Weapon { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TargetType? Target { get; set; }
        public bool IsSuccessful { get; set; }
        public bool IsSuicide { get; set; }
        public Casualties? Casualties { get; set; }
        public string? Source { get; set; }
        public DateTime LastUpdated { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }

    [Owned]
    public class Casualties
    {
        public int? Fatalities { get; set; }
        public int? Injuries { get; set; }
        public int? Total => (Fatalities ?? 0) + (Injuries ?? 0);
    }


    public enum IncidentType
    {
        All,
        Islamic,
        Domestic,
        Left_Wing,
        Right_Wing,
        Separatist,
        Cyber,
        Environmental,
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
}
