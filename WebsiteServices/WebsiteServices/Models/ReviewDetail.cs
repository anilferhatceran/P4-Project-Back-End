using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class ReviewDetail
    {
        [Key]
        public int reviewID { get; set; }
        [Required]
        public CompanyProfile company { get; set; }
        public User user { get; set; }
        public string reviewTitle { get; set; }
        public string reviewText { get; set; }
        public string reviewDate { get; set; }
        public int reviewRating { get; set; }
    }
}
