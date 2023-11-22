using ExternalApiTesting.Models;
using ExternalApiTesting.Repositories.Contracts;
using System.Text.Json;

namespace ExternalApiTesting.Repositories
{
    public class HolidayApiService : IHolidaysApiService
    {
        private readonly HttpClient httpClient;

        public HolidayApiService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("PublicHolidaysApi");
        }

        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v3/PublicHolidays/{0}/{1}", year, countryCode);

            var result = new List<HolidayModel>();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                            new JsonSerializerOptions()
                            {
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                            });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
