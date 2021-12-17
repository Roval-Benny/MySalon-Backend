using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Exceptions;
using MySalonModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService user)
        {
            _userService = user;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(_userService.GetAllUser());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }catch(UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<UserController>/5
        [HttpGet("{phoneNo}")]
        public IActionResult GetUser(string phoneNo)
        {
            try
            {
                User obj = _userService.GetUser(phoneNo);
                return Ok(obj);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
           
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            try
            {
                User result = _userService.CreateUser(user);
                return Created("", result);
            }
            catch (UserAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{phoneNo}")]
        public IActionResult DeleteUser(string phoneNo)
        {
            try
            {
                _userService.DeleteUser(phoneNo);
                return Ok(true);
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
