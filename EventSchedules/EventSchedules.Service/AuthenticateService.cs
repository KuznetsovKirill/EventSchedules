using AutoMapper;
using EventSchedules.Data.Contract;
using EventSchedules.Service.Contract;
using EventSchedules.Service.Dto;
using EventSchedules.Service.Wrapper.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Service
{
    internal class AuthenticateService : IAuthenticateService
    {
        private IContextManager _contextManager;
        private readonly IMapper _mapper;
        private IHashWrapeer _hashWrapper;
     
        public AuthenticateService(IContextManager contextManager, IHashWrapeer hashWrapper, IMapper mapper)
        {
            _contextManager = contextManager;
            _hashWrapper = hashWrapper;
            _mapper = mapper;
        }

        public UserDto Authenticate(UserLoginDto dto)
        {
            var repo = _contextManager.CreateRepositiry<IUserRepo>();

            var hashPass = _hashWrapper.GetHashString(dto.Password);
            var user = repo.GetUserByEmailPassword(dto.Email, hashPass);

            if (user == null)
            {
                throw new ValidationException("Incorrect Email/Password combination");
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }
    }
}
