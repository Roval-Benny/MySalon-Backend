using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Exceptions;
using MySalonModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartServiceController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartServiceController(ICartService service)
        {
            _cartService = service;
        }
        // GET: api/<CartServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartServiceController>/5
        [HttpGet("{userId}")]
        public IActionResult GetAllCartItemByUserId(int userId)
        {
            try
            {
                List<Cart> list = _cartService.GetAllCartItemByUserId(userId);
                return Ok(list);
            }
            catch(UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<CartServiceController>
        [HttpPost]
        public IActionResult AddItemToCart([FromBody] Cart value)
        {
            try
            {
                return Ok(_cartService.AddItemToCart(value));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<CartServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartServiceController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteACartItem(int id)
        {
            try
            {
                _cartService.DeleteACartItem(id);
                return Ok(true);
            }
            catch(CartItemNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
