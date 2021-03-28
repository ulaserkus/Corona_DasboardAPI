using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Dtos
{
    public class CountryDetailsDto
    {
        public double Patient { get; set; }

        public double Death { get; set; }

        public double Cure { get; set; }

        public DateTime AddedTime { get; set; }

        public int CountryId { get; set; }

    }
}
