using ExternalApiTesting.Models;
using ExternalApiTesting.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesApiService _countriesApiService;

        public CountryController(ICountriesApiService countriesApiService)
        {
            _countriesApiService = countriesApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountroInfo(string countryCode)
        {
            try
            {
                CountryInfoModel countryInfos = new CountryInfoModel();

                if (!string.IsNullOrEmpty(countryCode))
                {
                    countryInfos = await _countriesApiService.GetCountryInfos(countryCode);
                }

                return Ok(countryInfos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the server");
            }
        }
    }
}
