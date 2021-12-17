using DAL;
using MySalonModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Services;
using System;
using Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        // GET: api/<SalonController>

        private readonly ISalonService _context;

        public SalonController(ISalonService con)
        {
            _context = con;
        }

        // GET api/<SalonController>/5
        [HttpGet("{location}")]
        public IActionResult GetAllSalonByLocation(string location) 
        {
            try
            {
                List<Salon> salons = _context.GetAllSalonsByLocation(location);
                return Ok(salons);
            }
            catch (SalonNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllSalon()
        {
            try {
                List<Salon> salons = _context.GetAllSalons();
                return Ok(salons);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<SalonController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetSalonById(int id)
        {
            try
            {
                Salon salon = _context.GetSalon(id);
                return Ok(salon);
            }catch(SalonNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       

        // POST api/<SalonController>
        [HttpPost]
        public IActionResult Post([FromBody] Salon value)
        {
            try
            {
                Salon salon = _context.CreateSalon(value);
                return Created("true",salon);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SalonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
