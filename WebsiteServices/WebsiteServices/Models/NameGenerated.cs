using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class NameGenerated
    {
        [Key]
        public int nameGenID { get; set; }
        public string generatedName { get; set; }
        public string maleNames { get; set; }
        public string femaleNames { get; set; }
        public User user{ get; set; }

    }
}
