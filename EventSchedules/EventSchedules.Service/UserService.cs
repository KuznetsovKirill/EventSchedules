using AutoMapper;
using EventSchedules.Data.Contract;
using EventSchedules.Model;
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
    internal class UserService : IUserService
    {
        private IContextManager _contextManager;
        private readonly IMapper _mapper;
        private IHashWrapeer _hashWrapper;

        public UserService(IContextManager contextManager, IMapper mapper, IHashWrapeer hashWrapper)
        {
            _contextManager = contextManager;
            _mapper = mapper;
            _hashWrapper = hashWrapper;
        }

        public User CreateUser(UserCreateDto dto)
        {
            var repo = _contextManager.CreateRepositiry<IUserRepo>();
            var user = repo.GetUserByEmail(dto.Email);

            if (!(user == null))
            {
                throw new ValidationException("User with email address <" + dto.Email + "> is already exists.");
            }

            dto.Password = _hashWrapper.GetHashString(dto.Password);

            var repoUser = _contextManager.CreateRepositiry<IUserRepo>();
            User entity = new User(dto.Email, dto.Password, dto.FirstName, dto.LastName);
            repoUser.Add(entity);
            _contextManager.Save();
            return entity;
        }

        public void DeleteUser(int id)
        {
            var repo = _contextManager.CreateRepositiry<IUserRepo>();
            var data = repo.GetById(id);
            var entity = repo.Delete(data);
            _contextManager.Save();
        }

        public UserDto UpdateUser(int id, UserDto dto)
        {          

            var repo = _contextManager.CreateRepositiry<IUserRepo>();
            var data = repo.GetById(id);

            data.FirstName = dto.FirstName;
            data.LastName = dto.LastName;
        
            _contextManager.Save();
            return _mapper.Map<UserDto>(data);
        }
    }
}
