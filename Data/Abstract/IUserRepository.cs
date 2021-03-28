using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldAPI.Models;

namespace WorldAPI.Data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser();

    }
}
