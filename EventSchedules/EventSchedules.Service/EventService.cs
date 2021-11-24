using AutoMapper;
using EventSchedules.Data.Contract;
using EventSchedules.Model;
using EventSchedules.Service.Contract;
using EventSchedules.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service
{
    internal class EventService : IEventService
    {
        private IContextManager _contextManager;
        private readonly IMapper _mapper;

        public EventService(IContextManager contextManager, IMapper mapper)
        {
            _contextManager = contextManager;
            _mapper = mapper;
        }

        public Event CreateEvent(EventCreateDto dto)
        {
            var repoUser = _contextManager.CreateRepositiry<IUserRepo>();
            var user = repoUser.GetById(dto.UserCreateId);

            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            var repo = _contextManager.CreateRepositiry<IEventRepo>();
            Event entity = new Event(dto.Name, dto.UserCreateId, dto.Description, dto.HoldingDate);
            repo.Add(entity);
            _contextManager.Save();

            //user.Events.Add(entity);
            _contextManager.Save();
            return entity;
        }

        public IEnumerable<EventDto> GetAll()
        {
            var repo = _contextManager.CreateRepositiry<IEventRepo>();
            var data = repo.GetAll();
            return data.Select(x => _mapper.Map<EventDto>(x)).ToList();
        }

        public List<EventDto> GetEventByUserOwnerId(int UserId)
        {
            var repo = _contextManager.CreateRepositiry<IEventRepo>();
            var data = repo.GetAllEventsByUser(UserId);
            var result = _mapper.Map<List<EventDto>>(data);
            return result;
        }

        public EventDto UpdateEvent(EvenUpdateDto dto)
        {
            var repo = _contextManager.CreateRepositiry<IEventRepo>();
            var data = repo.GetById(dto.Id);

            data.Name = dto.Name;
            data.HoldingDate = dto.HoldingDate;
            data.Description = dto.Description;
            data.Status = dto.Status;
      
            _contextManager.Save();
            return _mapper.Map<EventDto>(data);
        }

        public void DeleteEvent(int id)
        {
            var repo = _contextManager.CreateRepositiry<IEventRepo>();
            var data = repo.GetById(id);
            repo.Delete(data);
            _contextManager.Save();
        }
    }
}
