
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteServices.Models
{
    public class TypingSession
    {
        [Key]
        public int sessionID { get; set; }
        public int charactersTyped { get; set; }
        public int wordsPerMin { get; set; }
        public string time { get; set; }
    }
}
