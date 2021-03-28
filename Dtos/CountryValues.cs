using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Dtos
{
    public class CountryValues
    {
        public string CountryName { get; set; }

        public double Patient { get; set; }

        public double Death { get; set; }

        public double Cure { get; set; }
    }
}
