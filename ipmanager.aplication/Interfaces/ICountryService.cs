using ipmanager.aplication.ProxyDTOs;

namespace ipmanager.aplication.Interfaces
{
    public interface ICountryService
    {
        Task<CountryInfoResponse> GetCountryInfo(string name);
    }
}
