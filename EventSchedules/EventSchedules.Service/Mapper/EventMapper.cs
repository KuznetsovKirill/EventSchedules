using AutoMapper;
using EventSchedules.Model;
using EventSchedules.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Mapper
{

    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventDto, Event>().ReverseMap();
        }
    }
}
