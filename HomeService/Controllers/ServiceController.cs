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
        public List<Service> Get()
        {
            return _serviceService.GetAllService();
        }

        // POST api/<ServiceController>
        [HttpPost]
        public Service Add([FromBody] Service service)
        {
            return _serviceService.AddService(service);
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Service service)
        {
            if (_serviceService.DeleteService(service))
                return Ok("true");
            else
            {
                return NotFound($"User with id: {service} does not exist");
            }
        }
    }
}
