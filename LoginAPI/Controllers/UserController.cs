using LoginAPI.Models;
using LoginAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return UserService.GetAll();
        }
        // GET by username action
        [HttpGet("{username}")]
        public ActionResult<User> Get(string username)
        {
            return UserService.Get(username);
        }

        [HttpPost]
        // POST action
        public IActionResult Create(string username, string password)
        {
            UserService.Add(username, password);
            return CreatedAtAction(nameof(Create), new {Username = username, Password = password});
        }

        // PUT action
        [HttpPut("{user}")]
        public IActionResult Update(User user, string password)
        {
            if (password != user.Password)
                return BadRequest();

            var existingUser = UserService.Get(user.Username);
            if (existingUser is null)
                return NotFound();

            UserService.Update(user, password);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{user}")]
        public IActionResult Delete(User user)
        {
            UserService.Delete(user);

            return NoContent();
        }
    }
}
