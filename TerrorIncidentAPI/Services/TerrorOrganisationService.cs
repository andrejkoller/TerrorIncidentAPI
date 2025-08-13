using Microsoft.EntityFrameworkCore;
using TerrorIncidentAPI.Models;

namespace TerrorIncidentAPI.Services
{
    public class TerrorOrganisationService(TerrorIncidentDbContext context)
    {
        public async Task<List<TerrorOrganisation>> GetTerrorOrganisationsAsync()
        {
            var terrorOrganisations = await context.TerrorOrganisations
                .Select(t => new TerrorOrganisation
                {
                    Id = t.Id,
                    Name = t.Name,
                    Alias = t.Alias
                }).ToListAsync();

            return terrorOrganisations;
        }
    }
}
