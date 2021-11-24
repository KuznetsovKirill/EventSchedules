using EventSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Contract
{
    public interface IEventRepo : IRepository<Event>
    {
        List<Event> GetAllEventsByUser(int UserId);
    }
}
