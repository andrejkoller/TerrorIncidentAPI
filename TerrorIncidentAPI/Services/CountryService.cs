using Microsoft.EntityFrameworkCore;
using TerrorIncidentAPI.Models;

namespace TerrorIncidentAPI.Services
{
    public class CountryService(TerrorIncidentDbContext context)
    {
        public async Task<List<Country>> GetCountriesAsync()
        {
            var countries = await context.Countries
                .Select(c => new Country
                {
                    Id = c.Id,
                    IsoCode = c.IsoCode,
                    Name = c.Name,
                    Latitude = Convert.ToDouble(c.Latitude),
                    Longitude = Convert.ToDouble(c.Longitude),
                    Incidents = c.Incidents == null
                        ? new List<Incident>()
                        : c.Incidents.Select(i => new Incident
                        {
                            Id = i.Id,
                            Title = i.Title,
                            Location = i.Location,
                            Description = i.Description,
                            Latitude = i.Latitude,
                            Longitude = i.Longitude,
                            Date = i.Date,
                            Type = i.Type,
                            Severity = i.Severity,
                            Weapon = i.Weapon,
                            Target = i.Target,
                            IsSuccessful = i.IsSuccessful,
                            IsSuicide = i.IsSuicide,
                            Casualties = i.Casualties == null
                                ? null
                                : new Casualties
                                {
                                    Fatalities = i.Casualties.Fatalities,
                                    Injuries = i.Casualties.Injuries
                                },
                            Source = i.Source,
                            LastUpdated = i.LastUpdated,
                            CountryId = i.CountryId,
                        }).ToList()
                }).ToListAsync();

            return countries;
        }
    }
}
