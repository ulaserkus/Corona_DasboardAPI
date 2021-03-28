using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldAPI.Models
{
    public class Country
    {

  
        public int Id { get; set; }
       

        public string CountryName { get; set; }


        public int MaxLatitude { get; set; }

        public int MinLatitude { get; set; }


        public int MaxLongtitude { get; set; }

        public int MinLongtitude { get; set; }




        public List<CountryDetails> CountryDetails { get; set; }

      
        public List<City> Cities { get; set; }

            
    }
}
