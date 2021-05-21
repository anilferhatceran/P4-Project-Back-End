using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userEmail { get; set; }
        public string passwordHash { get; set; }
    }
}
