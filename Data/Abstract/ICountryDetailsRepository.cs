using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Dtos;
using WorldAPI.Models;

namespace WorldAPI.Data.Abstract
{
    public interface ICountryDetailsRepository : IRepository<CountryDetails>
    {
        List<CountryValues> GetCountries();

        List<CountryValues> GetAdminCountries();

        List<CountryDetails> GetCountryDetails(string countryName);

        void CreateCity(CountryDetails countryDetails);

        ChangedValues GetLastInsert();

    }
}
