using EventSchedules.Model;
using EventSchedules.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Contract
{
  
    public interface IUserService
    {
        User CreateUser(UserCreateDto dto);

        UserDto UpdateUser(int id, UserDto model);

        void DeleteUser(int id);
    }
}
