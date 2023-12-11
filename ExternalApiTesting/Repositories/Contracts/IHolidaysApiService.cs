using ExternalApiTesting.Models;

namespace ExternalApiTesting.Repositories.Contracts
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);

        Task<CountryInfoModel> GetCountryInfos(string countryCode);
    }
}
