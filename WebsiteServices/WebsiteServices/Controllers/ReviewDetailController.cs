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
     
            var companyByUrl = dataContext.ReviewDetails.Where(webUrl => webUrl.company.companyURL == url);
            return companyByUrl;

        }

        [HttpGet("rating")]
        public int GetAvrgRating(string url)
        {
            List<CompanyProfile> companyProfilesList = dataContext.CompanyProfiles.ToList();

            List<User> userList = dataContext.Users.ToList();

           
            
            var companyByUrl = dataContext.ReviewDetails.Where(reviewTotal => reviewTotal.company.companyURL == url).Select(totalReviewRating => totalReviewRating.reviewRating);

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

            var companyByUrl = dataContext.ReviewDetails.Where(reviewTotal => reviewTotal.company.companyURL == url).Select(totalReviewRating => totalReviewRating.reviewRating);

            int totalRatings = companyByUrl.Count();

            return totalRatings;
        }





        // POST api/<ReviewDetailController>
        [HttpPost]
        public async Task<ActionResult<ReviewDetail>> PostReviw(ReviewDetail reviewDetail)
        {

            
            var companyCheck = dataContext.CompanyProfiles.Where(company => company.companyURL == reviewDetail.company.companyURL
            && company.companyName == reviewDetail.company.companyName).FirstOrDefault();

            if(companyCheck != null)
            {
                reviewDetail.company = companyCheck;
            }
            else
            {
                dataContext.CompanyProfiles.Add(reviewDetail.company);
            }
            dataContext.ReviewDetails.Attach(reviewDetail);
            await dataContext.SaveChangesAsync();


            return reviewDetail;


        }
        //[HttpPost]
        //public async Task<ActionResult<ReviewDetail>> PostCompany(CompanyProfile company)
        //{
        //    dataContext.CompanyProfiles.Add(company);
        //    await dataContext.SaveChangesAsync();
        //    return company;
        //}

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
