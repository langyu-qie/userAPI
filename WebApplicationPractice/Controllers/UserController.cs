using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPractice.Model;
using WebApplicationPractice.Repository;
//using WebApplicationPractice.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationPractice.Controllers
{
    [EnableCors("AllowAllCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userRepository.Users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = _userRepository.Users.Count + 1;
            _userRepository.Users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var existingUser = _userRepository.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepository.Users.Remove(user);
            return NoContent();
        }





















        //// GET: api/<ValuesController>
        //[HttpGet("{id}")]
        //public IActionResult GetUserById(int id)
        //{
        //    var user = _userService.GetUserById(id);
        //    return Ok(user);

        //}

        //[HttpGet]
        //public IActionResult GetAllUsers()
        //{
        //    var userList = _userService.GetAllUsers();
        //    return Ok(userList);

        //}


        //// POST api/<ValuesController>
        //[HttpPost]
        //public IActionResult CreateUser([FromBody] User user)
        //{
        //    _userService.CreateUser(user);
        //    return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]

        //public IActionResult UpdateUser(int id, [FromBody] User user)
        //{
        //    _userService.UpdateUser(id, user);
        //    return NoContent();
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _userService.DeleteUser(id);
        //    return NoContent();
        //}
    }
}
