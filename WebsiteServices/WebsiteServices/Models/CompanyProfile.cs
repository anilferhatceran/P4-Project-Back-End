using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class CompanyProfile
    {
        [Key]
        public int companyID { get; set; }
        public string companyName { get; set; }
        public string companyURL { get; set; }
    }
}
