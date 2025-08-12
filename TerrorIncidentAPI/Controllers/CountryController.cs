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
                return Ok(countries);
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
