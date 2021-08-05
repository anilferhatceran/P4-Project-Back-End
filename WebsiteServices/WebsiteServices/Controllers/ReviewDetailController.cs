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

           
            //Finds all the reviews given to the company by matchig the companyURL with the user-input url given on the front end.
            var companyByUrl = dataContext.ReviewDetails.Where(reviewTotal => reviewTotal.company.companyURL == url).Select(totalReviewRating => totalReviewRating.reviewRating);

            int avrgRating;
            
            //If the company has more than 0 reviews, this if is executed
            if (companyByUrl.Count() > 0)
            {
                //get the sum of all the reviews given and then divide that number by the amount of reviews given.
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
        public async Task<ActionResult<ReviewDetail>> PostReview(ReviewDetail reviewDetail)
        {

            //this checks whether the companyName and companyURL exist in the ReviewDetail model.
            //If they do exist, it means that the company has reviews attached to it
            //if not, then the company gets added to the reviewDetail model, which means the first review is ready to get posted.
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
