using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Dtos;
using WorldAPI.Models;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository _CountryRepository;
        private ICountryDetailsRepository _CountryDetailsRepository;

        private IMapper _IMapper;

        public CountryController(ICountryRepository CountryRepository, IMapper IMapper, ICountryDetailsRepository CountryDetailsRepository)
        {
            _CountryRepository = CountryRepository;
            _CountryDetailsRepository = CountryDetailsRepository;
            _IMapper = IMapper;

        }


        [HttpGet]
        public ActionResult GetAllCountry()
        {
            var countries = _CountryDetailsRepository.GetCountries();


            return Ok(countries);
        }
        [HttpGet("orderbyname")]
        public ActionResult GetCountryListByName()
        {
            var countries = _CountryDetailsRepository.GetCountries().OrderBy(x => x.CountryName);


            return Ok(countries);
        }
        [HttpGet("orderbypatient")]
        public ActionResult GetCountryListByPatient()
        {
            var countries = _CountryDetailsRepository.GetCountries().OrderByDescending(x => x.Patient);


            return Ok(countries);
        }
        [HttpGet("orderbydeath")]
        public ActionResult GetCountryListByDeath()
        {
            var countries = _CountryDetailsRepository.GetCountries().OrderByDescending(x => x.Death);


            return Ok(countries);
        }
        [HttpGet("orderbycure")]
        public ActionResult GetCountryListByCure()
        {
            var countries = _CountryDetailsRepository.GetCountries().OrderByDescending(x => x.Cure);


            return Ok(countries);
        }




        [HttpGet("admin")]
        public ActionResult GetAdminCountries()
        {
            var countries = _CountryDetailsRepository.GetAdminCountries();


            return Ok(countries);
        }


        [HttpGet("values")]

        public async Task<ActionResult> GetAllValues()
        {

            var totalValues = await _CountryRepository.TotalValues();


            return Ok(totalValues);
        }

        [HttpGet("changedvalues")]
        public ActionResult GetChangedValues()
        {
            var changedValues = _CountryDetailsRepository.GetLastInsert();


            return Ok(changedValues);
        }


        [HttpGet("percantage")]

        public async Task<ActionResult> GetPercantageValues()
        {
            
           var percantages = await _CountryRepository.GetCountryPercantages();


            return Ok(percantages);
        }


        [HttpGet("valuesbydate")]
        public async Task<ActionResult> GetValuesByDate()
        {
            var valuesBy = await _CountryRepository.ValuesByWorld();

            return Ok(valuesBy);
        }


        [HttpGet("valuesbycountry")]
        public async Task<ActionResult> GetValuesByDateCountry(string countryName)
        {
            var valuesByCountry = await _CountryRepository.ValuesByCountry(countryName);


            return Ok(valuesByCountry);
        }

        [HttpGet("detail")]
        public ActionResult GetCountryByName(string countryName)
        {
            var countryDetails = _CountryDetailsRepository.GetCountryDetails(countryName);
            var countryDetailsToReturn = _IMapper.Map<List<CountryDetailsDto>>(countryDetails);
            return Ok(countryDetailsToReturn);
        }

        [HttpGet("countryId")]
        public async Task<ActionResult> GetCountryId(string countryName)
        {
            int id = await _CountryRepository.getCountryIdByName(countryName);
            return Ok(id);
        }


        [HttpPost]
        [Route("addDetail")]
        public IActionResult AddCountryDetail(CountryDetails countryDetails)
        {


            if (countryDetails != null)
            {

                _CountryDetailsRepository.CreateCity(countryDetails);
                _CountryDetailsRepository.Create(countryDetails);
                return Ok(countryDetails);

            }


            return BadRequest();
        }

        [HttpPost]
        [Route("addCountry")]
        public ActionResult AddCountry([FromBody] Country country)
        {

            if (country == null)
            {
                return BadRequest();
            }

            _CountryRepository.Create(country);


            return Ok("kayıt tamamlandı");
        }
    }
}
