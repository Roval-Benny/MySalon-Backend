using Exceptions;
using Microsoft.AspNetCore.Mvc;
using MySalonModels;
using Services;
using System;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _service;
        
        public TimeSlotController(ITimeSlotService ser)
        {
            _service = ser;
        }
        // GET: api/<TimeSlotController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TimeSlotController>/5
        [HttpGet("{salonId:int}/{date}")]
        public IActionResult GetTimeSlotsBySalonId(int salonId,string date)
        {
            try
            {
                List<TimeSlot> slot = _service.GetTimeSlotsBySalonId(salonId, date);
                return Ok(slot);
            }
            catch(TimeSlotNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{salonId:int}/{serviceId:int}/{date}")]
        public IActionResult GetTimeSlotsByServiceId(int salonId,int serviceId,string date)
        {
            try
            {
                TimeSlot slot = _service.GetTimeSlotByServiceId(salonId, serviceId, date);
                return Ok(slot);
            }
            catch (TimeSlotNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TimeSlotController>
        [HttpPost]
        public IActionResult CreateTimeSlot([FromBody] TimeSlot value)
        {
            try
            {
                TimeSlot time = _service.CreateTimeSlot(value.SalonId,value.ServiceId,value.Date);
                return Ok(time);
            }
            catch(NullValueException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TimeSlotController>/5
        [HttpPut("{salonId:int}/{serviceId:int}/{date}")]
        public IActionResult UpdateTimeSlot(int salonId,int serviceId,string date, [FromBody] TimeSlot value)
        {
            try
            {
                _service.UpdateTimeSlot(salonId, serviceId, date, value);
                return Ok("updated");
            }catch(NullValueException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TimeSlotController>/5
        [HttpDelete("{salonId:int}/{serviceId:int}/{date}")]
        public IActionResult DeleteTimeSlot(int salonId,int serviceId,string date)
        {
            try
            {
                _service.DeleteTimeSlot(salonId, serviceId, date);
                return Ok("Deleted");
            }catch (TimeSlotNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
