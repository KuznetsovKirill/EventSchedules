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
    public class UserMapper : Profile
    {
        public UserMapper()
        { 
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
