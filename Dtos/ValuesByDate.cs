using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Dtos
{
    public class ValuesByDate
    {
        public List<double> TotalDeathsByDate { get; set; }

        public List<double> TotalCuresByDate { get; set; }

        public List<double> TotalPatientsByDate { get; set; }

        public List<string> Dates { get; set; }


    }
}
