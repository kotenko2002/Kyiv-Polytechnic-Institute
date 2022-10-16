using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Lab_1.Models;
using Lab_1.Data;

namespace Lab_1.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Empty request body");
            }

            if (DbContext.Users.Any(item => item.Id == user.Id))
            {
                return BadRequest("User with such Id already exists");
            }

            DbContext.Users.Add(user);
            return Ok("Success");
        }
    }
}
