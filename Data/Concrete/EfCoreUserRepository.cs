using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Data.Abstract;
using WorldAPI.Models;

namespace WorldAPI.Data.Concrete
{
    public class EfCoreUserRepository : EfCoreGenericRepository<User, DataContext>, IUserRepository
    {
        public User GetUser()
        {
            using (var context = new DataContext())
            {


               var user =  context.Users.Where(x => x.UserName=="admin").FirstOrDefault();

                return user;

            }
        }
    }
}
