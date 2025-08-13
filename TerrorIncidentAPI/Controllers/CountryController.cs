using Microsoft.AspNetCore.Mvc;
using TerrorIncidentAPI.Services;

namespace TerrorIncidentAPI.Controllers
{
    [ApiController]
    public class CountryController(CountryService service) : Controller
    {
        [HttpGet("api/countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await service.GetCountriesAsync();

                if (countries != null && countries.Count != 0)
                {
                    return Ok(countries);
                }

                return NotFound(new { Message = "No countries found." });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        Message = "An error occurred while retrieving countries.",
                        Details = ex.Message
                    });
            }
        }
    }
}
