using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebsiteServices.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext>options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<NameGenerated> NamesGenerated { get; set; }
        public DbSet<TypingSession> TypingSessions { get; set; }
        public DbSet<TextGenerator> TextsGenerated { get; set; }
        public DbSet<NameGenUser> NameGenUsers { get; set; }
    }
}
