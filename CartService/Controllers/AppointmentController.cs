using Microsoft.AspNetCore.Mvc;
using Exceptions;
using DAL;
using MySalonModels;
using Services;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        // GET: api/<AppointmentController>

        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService ser)
        {
            _service = ser;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppointmentController>/5
        [HttpGet("user/{userId}")]
        public IActionResult GetAllAppointmentByUserId(int userId)
        {
            try
            {
                return Ok(_service.GetAllAppointmentByUserId(userId));
            }catch(UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("admin/{adminId}")]
        public IActionResult GetAllAppointmentByAdminId(int adminId)
        {
            try
            {
                return Ok(_service.GetAllAppointmentByAdminId(adminId));
            }
            catch (AdminNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public IActionResult CreateAppointment([FromBody] Appointment value)
        {
            try
            {
                return Ok(_service.CreateAppointment(value)); ;
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}/{value}")]
        public IActionResult UpdateAppointment(int id, int value)
        {
            try
            {
                return Ok(_service.UpdateAppointment(value,id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            try
            {
                return Ok(_service?.DeleteAppointment(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
