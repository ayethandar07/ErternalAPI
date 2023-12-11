namespace ExternalApiTesting.Models
{
    public class CountryInfoModel
    {
        public string CommonName { get; set; }
        public string OfficialName { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public List<CountryInfoModel> Borders { get; set; }
    }
}
