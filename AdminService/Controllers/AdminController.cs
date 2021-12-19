using Microsoft.AspNetCore.Mvc;
using System;
using Services;
using Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySalonModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService service)
        {
            _adminService = service;
        }

        // GET: api/<AdminController>
        [HttpPost]
        public ActionResult Create([FromBody] Admin admin)
        {
            try
            {
                Admin userCreated = _adminService.CreateAdmin(admin);
                return Created("", userCreated);
            }
            catch (UserAlreadyExistsException uaex)
            {
                return Conflict(uaex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // GET api/<AdminController>/5
        [HttpGet("{phoneNo}")]
        public ActionResult Get(string phoneNo)
        {
            try
            {
                var getUser = _adminService.GetAdminByUserName(phoneNo);
                return Ok(getUser);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<AdminController>/5
        [HttpPut("{userName}")]
        public ActionResult Update([FromBody] Admin admin,string userName)
        {
            try
            {
                var updatedUser = _adminService.UpdateAdmin(admin, userName);
                return Ok(updatedUser);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deleteUser = _adminService.DeleteAdmin(id);
                return Ok(deleteUser);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
