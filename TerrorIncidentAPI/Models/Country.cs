namespace TerrorIncidentAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? IsoCode { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Incident>? Incidents { get; set; }
    }
}
