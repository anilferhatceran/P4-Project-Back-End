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
    public class ReviewDetailController : ControllerBase
    {
        private readonly DatabaseContext dataContext;

        public ReviewDetailController (DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }
        // GET: api/<ReviewDetailController>
        [HttpGet]
        public IEnumerable<ReviewDetail> GetReviews()
        {
            List<CompanyProfile> companyProfilesList = dataContext.CompanyProfiles.ToList();
            
            List<User> userList = dataContext.Users.ToList();

            List<ReviewDetail> reviewsList = dataContext.ReviewDetails.ToList();
            return reviewsList;

        }
        [HttpGet("company")]
        public IEnumerable<ReviewDetail> GetReviewByURL(string url)      
        {
            List<CompanyProfile> companyProfilesList = dataContext.CompanyProfiles.ToList();

            List<User> userList = dataContext.Users.ToList();

            List<ReviewDetail> reviewsList = dataContext.ReviewDetails.ToList();
            var companyByUrl = reviewsList.Where(webUrl => webUrl.company.companyURL == url);
            return companyByUrl;

        }

        [HttpGet("rating")]
        public int GetAvrgRating(string url)
        {
            List<CompanyProfile> companyProfilesList = dataContext.CompanyProfiles.ToList();

            List<User> userList = dataContext.Users.ToList();

            List<ReviewDetail> reviewsList = dataContext.ReviewDetails.ToList();
            
            var companyByUrl = reviewsList.Where(reviewTotal => reviewTotal.company.companyURL == url).Select(totalReviewRating => totalReviewRating.reviewRating);

            int avrgRating;
            

            if (companyByUrl.Count() > 0)
            {
                int ratingSum = companyByUrl.Sum();
                avrgRating = ratingSum / companyByUrl.Count();
                return avrgRating;
            }

            return avrgRating = 0;
                         
        }

        [HttpGet("totalratings")]
        public int TotalRatings(string url)
        {
            List<CompanyProfile> companyProfilesList = dataContext.CompanyProfiles.ToList();

            List<User> userList = dataContext.Users.ToList();

            List<ReviewDetail> reviewsList = dataContext.ReviewDetails.ToList();
            var companyByUrl = reviewsList.Where(reviewTotal => reviewTotal.company.companyURL == url).Select(totalReviewRating => totalReviewRating.reviewRating);

            int totalRatings = companyByUrl.Count();

            return totalRatings;
        }





        // POST api/<ReviewDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

class List
{
    List (int size)
    {
        firstElement = new Element();
        for (int i = 0; i < size; i++)
        {
            firstElement.next = new Element();
        }
    }
    Element firstElement;
}

class Element
{
    public Element next;
}
