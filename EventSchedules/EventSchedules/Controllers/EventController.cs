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
    //[Authorize]
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public IActionResult CreateEvent(EventCreateDto dto)
        {
            try
            {
                var data = _service.CreateEvent(dto);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Events()
        {
            try
            {
                var data = _service.GetAll();
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("geteventsbyuserId")]
        public IActionResult GetEventsByUserId(int id)
        {
            try
            {
                var data = _service.GetEventByUserOwnerId(id);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEvent([FromBody] EvenUpdateDto model)
        {
            try
            {
                var data = _service.UpdateEvent(model);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                _service.DeleteEvent(id);
                return Ok("successful user delete");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
