using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Business;
using ProjectManager.Entities;
using System.Collections.Generic;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userBL.GetUsers();
        }

        // GET: api/User/Search
        [HttpGet]
        [Route("Search")]
        public IEnumerable<User> Search(string searchText)
        {
            return _userBL.SearchUsers(searchText);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _userBL.AddUser(user);
                return Ok();
            }
            return BadRequest();
        }

        // PUT: api/User/5
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _userBL.UpdateUser(user);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/User/5
        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _userBL.DeleteUser(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
