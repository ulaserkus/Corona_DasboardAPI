using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Dtos;
using WorldAPI.Models;


namespace WorldAPI.Data.Abstract
{
    public interface ICountryRepository : IRepository<Country>
    {


        Task<double> TotalPatient();

        Task<TotalValues> TotalValues();

        Task<ValuesByDate> ValuesByWorld();

        Task<ValuesByDate> ValuesByCountry(string countryName);

        Task<CountryPercantages> GetCountryPercantages();

        Country GetCountryByName(string countryName);

        Task<int> getCountryIdByName(string countryName);
    }
}
