using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Dtos;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityRepository _CityRepository;
        private IMapper _Mapper;

        public CityController(ICityRepository CityRepository, IMapper Mapper)
        {
            _CityRepository = CityRepository;
            _Mapper = Mapper;
        }




        [HttpGet]
        public ActionResult GetAllCities()
        {
            var cityList = _CityRepository.GetAll();
            var cityListToReturn = _Mapper.Map<List<CityValues>>(cityList);

            return Ok(cityListToReturn);
        }


    }
}
