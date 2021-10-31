using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BasicWebApp.Classes;
using BasicWebApp.Models;
using BasicWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApp.Controllers
{
    [ApiVersion("1.0")]
    [Route("users")] //you cant use the controller square brackets for this one
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {
        
        private readonly UserService _userService;
        private readonly UsersContext _context;

        public UsersController(UserService userService, UsersContext context)
        {
            _userService = userService;
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<User> GetAllUsers([FromQuery] UserQueryParameters queryParameters)
        {
            return Ok(_userService.GetAll(_context.Users, queryParameters));
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            var user = _userService.GetOne(_context.Users, id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var statusCode = _userService.ValidatePostRequestInformation(user);
            if (statusCode is not OkResult) return statusCode;
            
            user.Id = Guid.NewGuid();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(
                "GetUser",
                new {id = user.Id},
                user
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser([FromRoute] Guid id, [FromBody] User user)
        {
            var statusCode = _userService.ValidatePutRequestInformation(_context.Users.AsQueryable(), id, user);
            switch (statusCode)
            {
                case BadRequestResult:
                    return statusCode;
                case NotFoundResult:
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
            
                    return CreatedAtAction(
                        "GetUser",
                        new {id = user.Id},
                        user
                    );
                case OkResult:
                {
                    var userToUpdate = _context.Users.First(userToFind => userToFind.Id == id);
                    _context.Entry(userToUpdate).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();
                    return Ok(user);
                }
            }

            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var statusCode = _userService.ValidateDeleteRequestInformation(_context.Users, id);
            if (statusCode is not OkResult) return statusCode;
            
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }        
        
    }
}