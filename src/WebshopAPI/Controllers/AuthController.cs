using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Models;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        // simple database simulation
        private static List<User> Users = new List<User>();

        [HttpPost("register")]
        public IActionResult Register(string theUsername, string thePassword)
        {
            // check if username already exists
            if (Users.Any(u => u.Username == theUsername))
            {
                // registraion failed
                return BadRequest("User already exists.");
            }
            // create new User
            User aNewUser = new User
            {
                Username = theUsername,
                Password = thePassword
            };
            Users.Add(aNewUser);
            // registration okay
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public IActionResult Login(string theUsername, string thePassword)
        {
            var user = Users.SingleOrDefault(u => u.Username == theUsername && u.Password == thePassword);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok();
        }
      

    }
}
