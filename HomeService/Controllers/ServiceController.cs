using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySalonModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly ILogger _logger;

        public ServiceController(IServiceService serviceService, ILogger<BranchController> logger)
        {
            _logger = logger;
            _serviceService = serviceService;
            _logger.LogInformation("hellp");

        }
        // GET: api/<ServiceController>
        [HttpGet]
        public IActionResult GetAllService()
        {
            try
            {
                List<Service> services = _serviceService.GetAllService();
                return Ok(services);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<ServiceController>
        [HttpPost]
        public IActionResult Add([FromBody] Service service)
        {
            try
            {
                Service ser = _serviceService.AddService(service);
                return Ok(ser);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {

                _serviceService.DeleteService(id);
                return Ok("Deleted");
            }catch(ServiceNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
