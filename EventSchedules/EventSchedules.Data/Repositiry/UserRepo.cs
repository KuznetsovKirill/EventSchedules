using EventSchedules.Data.Contract;
using EventSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Repositiry
{
     
    public class UserRepo : AbstractRepo<User>, IUserRepo
    {
        public User GetUserByEmail(string email)
        {
            var user = _eventShedulesContext.Set<User>().FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User GetUserByEmailPassword(string email, string password)
        {
            var user = _eventShedulesContext.Set<User>().FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }
    }
}
