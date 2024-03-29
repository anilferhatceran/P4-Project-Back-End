﻿using Microsoft.AspNetCore.Mvc;
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
    public class CompanyProfileController : ControllerBase
    {
        private readonly DatabaseContext dataContext;

        public CompanyProfileController(DatabaseContext dataContextObj)
        {
            dataContext = dataContextObj;
        }
        // GET: api/<CompanyProfileController>
        [HttpGet]
        public IEnumerable<CompanyProfile> GetCompanyProfiles()
        {
            List<CompanyProfile> companyList = dataContext.CompanyProfiles.ToList();

            return companyList;
        }

        // GET api/<CompanyProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyProfileController>
        [HttpPost]
        public async Task<ActionResult<CompanyProfile>> PostCompany(CompanyProfile company)
        {
            dataContext.CompanyProfiles.Add(company);
            await dataContext.SaveChangesAsync();
            return company;
        }

        // PUT api/<CompanyProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
