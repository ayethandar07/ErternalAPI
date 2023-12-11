using ExternalApiTesting.Models;

namespace ExternalApiTesting.Repositories.Contracts
{
    public interface ICountriesApiService
    {
        Task<CountryInfoModel> GetCountryInfos(string countryCode);

        Task<List<Country>> AvailableCountries();
    }
}
