using EventSchedules.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service.Contract
{
    public interface IAuthenticateService
    {
        UserDto Authenticate(UserLoginDto dto);
    }
}
