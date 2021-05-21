using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class TextGenerator
    {
        [Key]
        public int wordID { get; set; }
        public string word { get; set; }
    }
}
