using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Dtos;
using WorldAPI.Models;

namespace WorldAPI.Data.Concrete
{
    public class EfCoreCountryDetailsRepository : EfCoreGenericRepository<CountryDetails, DataContext>, ICountryDetailsRepository
    {

        public List<CountryValues> GetCountries()
        {
            using (var context = new DataContext())
            {
                var countryList = new List<CountryValues>();


                var AllValues = (from d in context.Countries
                                 join c in context.CountryDetails on d.Id equals c.CountryId

                                 select new
                                 {
                                     countryName = d.CountryName,
                                     totalPatient = d.CountryDetails.Sum(x => x.Patient),
                                     totalDeath = d.CountryDetails.Sum(x => x.Death),
                                     totalCure = d.CountryDetails.Sum(x => x.Cure),
                                 }).ToList().Distinct();


                foreach (var values in AllValues)
                {
                    var country = new CountryValues();
                    country.CountryName = values.countryName;
                    country.Cure = values.totalCure;
                    country.Patient = values.totalPatient;
                    country.Death = values.totalDeath;


                    countryList.Add(country);
                }
                return countryList;
            }

        }
        public List<CountryValues> GetAdminCountries()
        {
            using (var context = new DataContext())
            {
                var countryList = new List<CountryValues>();


                var AllValues = (from d in context.Countries
                                 select new
                                 {
                                     countryName = d.CountryName,
                                     totalPatient = d.CountryDetails.Sum(x => x.Patient),
                                     totalDeath = d.CountryDetails.Sum(x => x.Death),
                                     totalCure = d.CountryDetails.Sum(x => x.Cure),
                                 }).ToList().Distinct();


                foreach (var values in AllValues)
                {
                    var country = new CountryValues();
                    country.CountryName = values.countryName;
                    country.Cure = values.totalCure;
                    country.Patient = values.totalPatient;
                    country.Death = values.totalDeath;


                    countryList.Add(country);
                }
                return countryList;
            }

        }

        public List<CountryDetails> GetCountryDetails(string countryName)
        {
            using (var context = new DataContext())
            {

                return context.CountryDetails.Include(x => x.Country).Where(x => x.Country.CountryName == countryName).ToList();

            }
        }

        public ChangedValues GetLastInsert()
        {
            using (var context = new DataContext())
            {
                var values = new ChangedValues();

                values.TotalCure =  context.CountryDetails.OrderBy(x=>x.Id).Select(x => x.Cure).LastOrDefault();
                values.TotalDeaths =  context.CountryDetails.OrderBy(x => x.Id).Select(x => x.Death).LastOrDefault();
                values.TotalPatient =  context.CountryDetails.OrderBy(x => x.Id).Select(x => x.Patient).LastOrDefault();
                values.Total = values.TotalCure + values.TotalDeaths + values.TotalPatient;


                return  values;
            }
        }


        public void CreateCity(CountryDetails countryDetails)
        {
            using (var context = new DataContext())
            {
                var city =new City();
                var country = context.Countries.FirstOrDefault(x => x.Id == countryDetails.CountryId);

                city.Patient = countryDetails.Patient;
                city.Latitude = new Random().Next(country.MinLatitude,country.MaxLatitude+1);
                city.Longitude = new Random().Next(country.MinLongtitude, country.MaxLongtitude+1);
                city.Color = "red";
                city.CountryId = countryDetails.CountryId;

                context.Cities.Add(city);
                context.SaveChanges();
               
            }

        }
    }
}
