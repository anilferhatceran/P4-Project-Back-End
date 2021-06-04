using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebsiteServices.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext dataContext;

        public UserController(DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            List<User> userList = dataContext.Users.ToList();
            return userList;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IEnumerable<User> GetUsersByID(long id)
        {
            List<User> userList = dataContext.Users.ToList();
            var userByID = userList.Where(user => user.userID == id);

            return userByID;
        }

        // POST api/<UserController>
        [HttpGet("useremail")]
        public IEnumerable<User> GetUsersByEmail(string useremail)
        {
            List<User> userList = dataContext.Users.ToList();
            var userByEmail = userList.Where(user => user.userEmail == useremail);
            
            return userByEmail;
        }
        [HttpPost("login")]
        public ActionResult<User> ValidateUser(User user)
        {
            var userObj = dataContext.Users.FirstOrDefault(u => u.userEmail == user.userEmail && u.passwordHash == user.passwordHash);
            return userObj;
        }

       

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
