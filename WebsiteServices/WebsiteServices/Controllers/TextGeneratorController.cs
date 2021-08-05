using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextGeneratorController : ControllerBase

    {
        private readonly DatabaseContext dataContext;

        public TextGeneratorController(DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }

        [HttpGet("addWords")]
        public async Task<IActionResult> GenerateWordsList()
        {
            //reads all lines in the file specified and then adds each line to the lines array. This will only get executed once, so the specified path
            //of the file is not that important.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\anil\Downloads\english-words-master\english-words-master\words.txt");

            List<TextGenerator> items = new List<TextGenerator>();
            foreach (var item in lines)
            {
                //For each item(word) there is in the new array, an entry will be added to a list
                //However, before an item gets added to the list, we make sure that the added item is an object of our TextGenerator model.
                //In this case each item is equivalent to a word.
                items.Add(new TextGenerator() { word = item });
            }

            await dataContext.TextsGenerated.AddRangeAsync(items);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

       // GET: api/<TextGeneratorController>
        [HttpGet("words/{Amount}")]
        public ActionResult<string> GetWords(int amount)
        {
            //Refer to NameGeneratedController for the explanation of this code.


            List<TextGenerator> allWords = dataContext.TextsGenerated.ToList();
            List<TextGenerator> words = new List<TextGenerator>();
            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int num = rand.Next(0, allWords.Count - 1);
                words.Add(allWords[num]);
            }

            return Ok(new { words = string.Join(" ", words.Select(word => word.word))  });   
            
        }

        // GET api/<TextGeneratorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TextGeneratorController>
        [HttpPost]
        public async Task<ActionResult<TextGenerator>> PostText(TextGenerator text)
        {
            dataContext.TextsGenerated.Add(text);
            await dataContext.SaveChangesAsync();
            return text;
        }

        // PUT api/<TextGeneratorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TextGeneratorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
