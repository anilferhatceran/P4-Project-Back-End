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

            //Filters through a list of NameGenUser model and then finds all user entries
            //according to the user logged in. Then that list is reversed in order to get the newest entries.
            //To finish it of, the 10 newest entries are returned.
            var lastTen = nameGenUserList.Where(u => u.user.userID == userID).Reverse().Take(10);
           

            return lastTen;
        }

        // POST api/<NameGenUserController>
        [HttpPost]
        public async Task<ActionResult<NameGenUser>> PostNameGenUser(NameGenUser nameGenUser)
        {
            //This ensures that the user cannot save a name without clicking the generate method.
            //In othe words, the user cannot save "nothing".
            if(nameGenUser.name.maleNames == "" && nameGenUser.name.femaleNames == "")
            {
                return BadRequest();
            }
            
            //adds the saved name into the nameGenUser.name column
            nameGenUser.name = dataContext.NamesGenerated.Where(name => name.maleNames == nameGenUser.name.maleNames || name.femaleNames == nameGenUser.name.femaleNames).FirstOrDefault();

            //adds the userID of the user that saved the name, into the nameGenuser. user column.
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
