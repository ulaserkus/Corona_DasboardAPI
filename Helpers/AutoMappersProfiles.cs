using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Dtos;
using WorldAPI.Models;

namespace WorldAPI.Helpers
{
    public class AutoMappersProfiles : Profile
    {

        public AutoMappersProfiles()
        {
            CreateMap<CountryDetails, CountryDetailsDto>();


            CreateMap<City, CityValues>();

                CreateMap<CountryDetails, CountryDetailsDto>();
        }





    }
}
