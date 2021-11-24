using EventSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Contract
{
    public interface IUserRepo : IRepository<User>
    {
        User GetUserByEmail(string email);

        User GetUserByEmailPassword(string email, string password);
    }
}
