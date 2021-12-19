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
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly ILogger _logger;

        public BranchController(IBranchService branchService, ILogger<BranchController> logger)
        {
            _logger = logger;
            _branchService = branchService;
            _logger.LogInformation("hellp");

        }
        // GET: api/<BranchController>
        [HttpGet]
        public IActionResult GetAllBranches ()
        {
            try
            {
                return Ok(_branchService.GetAllBranch());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Branch branch = _branchService.GetBranchById(id);
                return Ok(branch);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
            // POST api/<BranchController>
        [HttpPost]
        public IActionResult Create([FromBody] Branch branch)
        {
            try
            {
                return Ok(_branchService.CreateBranch(branch));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
       
    }
}
