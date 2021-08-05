using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class NameGeneratedController : ControllerBase
    {
        // GET: api/<NameGeneratedController>
        private readonly DatabaseContext dataContext;

        public NameGeneratedController(DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }

        [HttpGet("addMaleNames")]
        public async Task<IActionResult> GenerateMaleNames()
        {
            //Read all lines from the given file and then add everything to an array.
            //For each item(name) there is in the new array, an entry will be added to a list
            //However, before an item gets added to the list, we make sure that the added item is an object of our NameGenerated model.
            //In this case each item is equivalent to a maleName.

            string[] maleNamesList = System.IO.File.ReadAllLines(@"C:\Users\anil\Desktop\maleNames.txt");

            List<NameGenerated> items = new List<NameGenerated>();

            foreach (var item in maleNamesList)
            {
                items.Add(new NameGenerated() { maleNames = item });
            }

            await dataContext.NamesGenerated.AddRangeAsync(items);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("addFemaleNames")]
        public async Task<IActionResult> GenerateFemaleNames()
        {
            string[] femaleNamesList = System.IO.File.ReadAllLines(@"C:\Users\anil\Desktop\femaleNames.txt");
            List<NameGenerated> items = new List<NameGenerated>();
            foreach (var item in femaleNamesList)
            {
                items.Add(new NameGenerated() { femaleNames = item });
            }

            await dataContext.NamesGenerated.AddRangeAsync(items);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("malenames/{amount}")]
        public async Task<List<string>> GetMaleNames(int amount)
        {
            //Get all male names from the NamesGenerated model and save them in a list.
            //Then we add a random maleName to a new list of strings, so it is a completely randomized list of male names.
            List<NameGenerated> maleNamesList = await dataContext.NamesGenerated.Where(name => name.maleNames != null).ToListAsync();
            List<string> maleNames = new List<string>();

            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                //random number from 0 to the length of the maleNamesList.
                int num = rand.Next(0, maleNamesList.Count - 1);
                //num represents a random index between 0 and the length of the maleNamesList.
                maleNames.Add(maleNamesList[num].maleNames);
            }

            return maleNames;
        }

        [HttpGet("femalenames/{amount}")]
        public async Task<List<string>> GetFemaleNames(int amount)
        {
            List<NameGenerated> femaleNamesList = await dataContext.NamesGenerated.Where(name => name.femaleNames != null).ToListAsync();
            List<string> femaleNames = new List<string>();

            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int num = rand.Next(0, femaleNamesList.Count - 1);
                femaleNames.Add(femaleNamesList[num].femaleNames);
            }

            return femaleNames;
        }

       

        //[HttpGet("maleName")]
        //public string GetMaleName()
        //{
        //    Random rand = new Random();
        //    int toSkip = rand.Next(0, dataContext.NamesGenerated.Where(name => name.maleNames != null).Count());
        //    return dataContext.NamesGenerated.Where(name => name.maleNames != null).Skip(toSkip).Take(1).First().maleNames;
            
        //}

        //[HttpGet("femaleName")]
        //public string GetFemaleName()
        //{
        //    Random rand = new Random();
        //    int toSkip = rand.Next(0, dataContext.NamesGenerated.Where(name => name.femaleNames != null).Count());
        //    return dataContext.NamesGenerated.Where(name => name.femaleNames != null).Skip(toSkip).Take(1).First().femaleNames;

        //}
        // POST api/<NameGeneratedController>


        // PUT api/<NameGeneratedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NameGeneratedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
