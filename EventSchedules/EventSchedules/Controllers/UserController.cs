using EventSchedules.Service.Contract;
using EventSchedules.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEventSchedules.Controllers
{
   // [Authorize]
    [Route("eventschedules/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IUserService _serviceUser;


        public UserController(IUserService service)
        {
            _serviceUser = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult CreateUser([FromBody] UserCreateDto model)
        {
            try
            {          
                var data = _serviceUser.CreateUser(model);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _serviceUser.DeleteUser(id);
                return Ok("successful user delete");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto dto)
        {
            try
            {
                var data = _serviceUser.UpdateUser(id, dto);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
