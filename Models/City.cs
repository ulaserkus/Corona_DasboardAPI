using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Models
{
    public class City
    {
        public int Id { get; set; }


        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Color { get; set; }

        public double Patient { get; set; }



        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
