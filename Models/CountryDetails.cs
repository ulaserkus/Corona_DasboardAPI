using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Models
{
    public class CountryDetails
    {

        public int Id { get; set; }

        public double Patient { get; set; }

        public double Death { get; set; }

        public double Cure { get; set; }

        public DateTime AddedTime { get; set; }


        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
