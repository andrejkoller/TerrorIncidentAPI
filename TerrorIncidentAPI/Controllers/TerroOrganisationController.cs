using Microsoft.AspNetCore.Mvc;
using TerrorIncidentAPI.Services;

namespace TerrorIncidentAPI.Controllers
{
    [ApiController]
    public class TerroOrganisationController(TerrorOrganisationService service) : Controller
    {
        [HttpGet("api/organisations")]
        public async Task<IActionResult> GetTerrorOrganisations()
        {
            try
            {
                var terrorOrganisations = await service.GetTerrorOrganisationsAsync();

                if (terrorOrganisations != null && terrorOrganisations.Count != 0)
                {
                    return Ok(terrorOrganisations);
                }

                return NotFound(new { Message = "No terror organisations found." });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        Message = "An error occurred while retrieving terror organisations.",
                        Details = ex.Message
                    });
            }
        }
    }
}
