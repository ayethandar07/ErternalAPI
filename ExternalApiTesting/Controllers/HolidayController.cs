using ExternalApiTesting.Models;
using ExternalApiTesting.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidaysApiService _holidaysApiService;

        public HolidayController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string countryCode, int year)
        {
            try
            {
                List<HolidayModel> holidays = new List<HolidayModel>();

                if (!string.IsNullOrEmpty(countryCode) && year > 0)
                {
                    holidays = await _holidaysApiService.GetHolidays(countryCode, year);
                }

                return Ok(holidays);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the server");
            }
            
        }
    }
}
