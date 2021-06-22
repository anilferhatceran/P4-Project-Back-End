using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class NameGenUser
    {
        [Key]
        public int nameGenUserID { get; set; }
        public NameGenerated name { get; set; }
        public User user { get; set; }
    }
}
