using Microsoft.AspNetCore.Mvc;
using DAL;
using MySalonModels;
using Services;
using Exceptions;
using System.Collections.Generic;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonServiceController : ControllerBase
    {
        private readonly ISalonServiceService _service;

        public SalonServiceController(ISalonServiceService ser)
        {
            _service = ser;
        }

        // GET: api/<SalonServiceController>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SalonServiceController>/5
        [HttpGet("{id}")]
        public IActionResult GetAllServiceBySalonId(int id)
        {
            try
            {
                List<SalonServices> service = _service.GetAllSalonServiceSalonId(id);
                return Ok(service);
            }catch(SalonNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SalonServiceController>
        [HttpPost]
        public IActionResult CreateSalonService([FromBody] SalonServices value)
        {
            try
            {
                SalonServices salon = _service.CreateSalonService(value);
                return Ok(salon);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SalonServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalonServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
