using ExternalApiTesting.Models;
using ExternalApiTesting.Repositories.Contracts;
using System.Net.Http;
using System.Text.Json;

namespace ExternalApiTesting.Repositories
{
    public class CountriesApiService : ICountriesApiService
    {
        private readonly HttpClient httpClient;

        public CountriesApiService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("PublicHolidaysApi");
        }

        public async Task<List<Country>> AvailableCountries()
        {
            var url = string.Format("/api/v3/AvailableCountries");

            var result = new List<Country>();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<Country>>(stringResponse,
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

        public async Task<CountryInfoModel> GetCountryInfos(string countryCode)
        {
            var url = string.Format("/api/v3/CountryInfo/{0}", countryCode);
            var result = new CountryInfoModel();

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<CountryInfoModel>(stringResponse,
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
