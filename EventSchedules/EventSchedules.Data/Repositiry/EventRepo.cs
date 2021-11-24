using EventSchedules.Data.Contract;
using EventSchedules.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Data.Repositiry
{
    public class EventRepo : AbstractRepo<Event>, IEventRepo
    {
        public List<Event> GetAllEventsByUser(int UserId)
        {
            var events = _eventShedulesContext.Set<Event>().Where(x => x.UserId == UserId)
                .OrderBy(x => x.Name)
                .ToList(); 
            return events;
        }
    }
}
