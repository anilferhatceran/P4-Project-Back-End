using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameGenUserController : ControllerBase
    {
        private readonly DatabaseContext dataContext;

        public NameGenUserController(DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }
        // GET: api/<NameGenUserController>
        [HttpGet]
        public IEnumerable<NameGenUser> GetNameGenUsers()
        {
            List<NameGenerated> nameGenList = dataContext.NamesGenerated.ToList();
            List<User> userList = dataContext.Users.ToList();
            List<NameGenUser> nameGenUserList = dataContext.NameGenUsers.ToList();
            
            return nameGenUserList;
        }

        [HttpGet("savednames/{userID}")]
        public IEnumerable<NameGenUser> GetLastTenNames(int userID)
        {
            List<NameGenerated> nameGenList = dataContext.NamesGenerated.ToList();
            List<User> userList = dataContext.Users.ToList();
            List<NameGenUser> nameGenUserList = dataContext.NameGenUsers.ToList();

            var lastTen = nameGenUserList.Where(u => u.user.userID == userID).Reverse().Take(10);
           

            return lastTen;
        }

        // POST api/<NameGenUserController>
        [HttpPost]
        public async Task<ActionResult<NameGenUser>> PostNameGenUser(NameGenUser nameGenUser)
        {
            nameGenUser.name = dataContext.NamesGenerated.Where(name => name.maleNames == nameGenUser.name.maleNames ||  name.femaleNames == nameGenUser.name.femaleNames).FirstOrDefault();

            nameGenUser.user = dataContext.Users.Where(user => user.userID == nameGenUser.user.userID).FirstOrDefault();

            dataContext.NameGenUsers.Add(nameGenUser);
            await dataContext.SaveChangesAsync();


            return nameGenUser;
        }
            
        // PUT api/<NameGenUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NameGenUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
