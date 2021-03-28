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
    public class EfCoreCountryRepository : EfCoreGenericRepository<Country, DataContext>, ICountryRepository
    {
        public async  Task<CountryPercantages> GetCountryPercantages()
        {

            using (var context = new DataContext())
            {
                CountryPercantages countryPercantages = new CountryPercantages();
                countryPercantages.CountryName = new List<string>();
                countryPercantages.PercantageValues = new List<double>();

                double totalpatient = await TotalPatient();


                // var Values = await context.CountryDetails.Where(x=>x.Country.Id==x.CountryId).Where(x => x.Patient * 100 / totalpatient >= 10).Select(i => i.Patient * 100 / totalpatient).ToListAsync();

                var AllValues = await (from d in context.Countries
                                       join c in context.CountryDetails on d.Id equals c.CountryId
                                       orderby d.CountryName

                                       select new
                                       {   countryName = d.CountryName,
                                           percantages = d.CountryDetails.Sum(x => x.Patient * 100 / totalpatient)

                                       }).Distinct().ToListAsync();

                var selectedValues = AllValues.Where(x => x.percantages >= 10);


                foreach (var round in selectedValues)
                {
                    var newNumber = Math.Round(round.percantages);
                    countryPercantages.PercantageValues.Add(newNumber);
                    countryPercantages.CountryName.Add(round.countryName);
                }



                return countryPercantages;
            }
        }     
    
    
        public async Task<TotalValues> TotalValues()
        {

            using (var context = new DataContext())
            {
                TotalValues totalValues = new TotalValues();

                totalValues.TotalDeaths = await context.CountryDetails.SumAsync(x => x.Death);
                totalValues.TotalCure = await context.CountryDetails.SumAsync(x => x.Cure);
                totalValues.TotalPatient = await context.CountryDetails.SumAsync(x => x.Patient);
                totalValues.Total = totalValues.TotalCure + totalValues.TotalDeaths + totalValues.TotalPatient;


                return totalValues;

            }
        }

        public async Task<double> TotalPatient()
        {

            using (var context = new DataContext())
            {
                return await context.CountryDetails.SumAsync(x => x.Patient);
            }
        }
     
   
        public async Task<ValuesByDate> ValuesByWorld()
        {
            using (var context = new DataContext())
            {
                ValuesByDate valuesBy = new ValuesByDate();
                valuesBy.Dates = new List<string>();
                valuesBy.TotalCuresByDate = new List<double>();
                valuesBy.TotalPatientsByDate = new List<double>();
                valuesBy.TotalDeathsByDate = new List<double>();

                var dateList = await context.CountryDetails.OrderBy(x => x.AddedTime).Select(x => x.AddedTime).Distinct().ToListAsync();

                foreach (var date in dateList)
                {
                    var totalPatient = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date).SumAsync(x => x.Patient);
                    valuesBy.TotalPatientsByDate.Add(totalPatient);
                  
                    var totalCure = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date).SumAsync(x => x.Cure);
                    valuesBy.TotalCuresByDate.Add(totalCure);

                    var totalDeath = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date).SumAsync(x => x.Death);
                    valuesBy.TotalDeathsByDate.Add(totalDeath);
                   
                    string formatted = string.Format("{0:%d MMMM yyyy}", date);


                    valuesBy.Dates.Add(formatted);

                }

              
                return valuesBy;

            }
        }

        public Country GetCountryByName(string countryName)
        {
            using (var context = new DataContext())
            {
                return context.Countries.Where(x => x.CountryName.ToLower() == countryName.ToLower()).FirstOrDefault();
            }
        }
    
        public async Task<ValuesByDate> ValuesByCountry(string countryName)
        {
            using (var context = new DataContext())
            {
                ValuesByDate valuesBy = new ValuesByDate();
                valuesBy.Dates = new List<string>();
                valuesBy.TotalCuresByDate = new List<double>();
                valuesBy.TotalPatientsByDate = new List<double>();
                valuesBy.TotalDeathsByDate = new List<double>();

                var dateList = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.Country.CountryName.ToLower() == countryName.ToLower()).Select(x => x.AddedTime).Distinct().ToListAsync();

                foreach (var date in dateList)
                {
                    var totalPatient = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date && x.Country.CountryName.ToLower() == countryName.ToLower()).SumAsync(x => x.Patient);
                    valuesBy.TotalPatientsByDate.Add(totalPatient);

                    var totalCure = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date && x.Country.CountryName.ToLower() == countryName.ToLower()).SumAsync(x => x.Cure);
                    valuesBy.TotalCuresByDate.Add(totalCure);

                    var totalDeath = await context.CountryDetails.OrderBy(x => x.AddedTime).Where(x => x.AddedTime == date && x.Country.CountryName.ToLower() == countryName.ToLower()).SumAsync(x => x.Death);
                    valuesBy.TotalDeathsByDate.Add(totalDeath);

                    string formatted = string.Format("{0:%d MMMM yyyy}", date);


                    valuesBy.Dates.Add(formatted);

                }


                return valuesBy;

            }

        }
        public async Task<int> getCountryIdByName(string countryName)
        {
            using (var context = new DataContext())
            {
                var countries = await context.Countries.Where(x => x.CountryName == countryName).ToListAsync();

                return countries.Select(x => x.Id).FirstOrDefault();
            }
        }

       
    }
}

