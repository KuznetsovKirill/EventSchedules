using EventSchedules.Model;
using EventSchedules.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Contract
{
    public interface IEventService
    {
        Event CreateEvent(EventCreateDto dto);

        IEnumerable<EventDto> GetAll();

        List<EventDto> GetEventByUserOwnerId(int UserId);

        EventDto UpdateEvent(EvenUpdateDto dto);

        void DeleteEvent(int id);
    }
}
