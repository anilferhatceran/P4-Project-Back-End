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
        //[HttpGet("MaleNames/{Amount}")]
        //public ActionResult<string> getMaleName(int amount)
        //{
        //    List<NameGenerated> allNames = dataContext.NamesGenerated.ToList();
        //    //List<NameGenerated> maleNames = new List<NameGenerated>();

        //    //Random rand = new Random();
        //    //for (int i = 0; i < amount; i++)
        //    //{
        //    //    int num = rand.Next(0, allNames.Count - 1);
        //    //    maleNames.Add(allNames[num]);
        //    //}

        //    var maleNames = allNames.Where(maleNames => maleNames.maleNames.Length > 1);
        //    return maleNames;
        //    //return Ok(new { maleNames = string.Join(" ", maleNames.Select(maleName => maleName.maleNames)) });

        //}

        [HttpGet("malenames/{amount}")]
        public async Task<List<string>> GetMaleNames(int amount)
        {
            List<NameGenerated> allNames = await dataContext.NamesGenerated.Where(name => name.maleNames != null).ToListAsync();
            List<string> maleNames = new List<string>();

            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int num = rand.Next(0, allNames.Count - 1);
                maleNames.Add(allNames[num].maleNames);
            }

            return maleNames;
        }

        [HttpGet("femalenames/{amount}")]
        public async Task<List<string>> GetFemaleNames(int amount)
        {
            List<NameGenerated> allNames = await dataContext.NamesGenerated.Where(name => name.femaleNames != null).ToListAsync();
            List<string> femaleNames = new List<string>();

            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int num = rand.Next(0, allNames.Count - 1);
                femaleNames.Add(allNames[num].femaleNames);
            }

            return femaleNames;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }
        [HttpGet("maleName")]
        public string GetMaleName()
        {
            Random rand = new Random();
            int toSkip = rand.Next(0, dataContext.NamesGenerated.Where(name => name.maleNames != null).Count());
            return dataContext.NamesGenerated.Where(name => name.maleNames != null).Skip(toSkip).Take(1).First().maleNames;
            
        }

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
