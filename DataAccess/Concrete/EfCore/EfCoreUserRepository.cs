using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreUserRepository : EfCoreGenericRepository<User, MsSqlContext>, IUserRepository
    {
        MsSqlContext _sqlContext = new MsSqlContext();

      

        public User GetByUsername(string username)
        {
            User user=null;
            foreach (var u in _sqlContext.User.ToList()) {
                if (u.Username == username) { 
                    user = u; break;
                }
            }

            return user;
                
        }
    }
}
