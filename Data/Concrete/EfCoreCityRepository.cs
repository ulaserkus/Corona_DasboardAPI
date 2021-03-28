using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Models;

namespace WorldAPI.Data.Concrete
{
    public class EfCoreCityRepository : EfCoreGenericRepository<City, DataContext>, ICityRepository
    {
      
    }
}
