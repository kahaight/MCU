using MCURelationalTest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MCUWebAPPTest.Models
{
    public class ClassesDbContext : DbContext
    {
        public ClassesDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CharacterMovie> CharacterMovies { get; set; }
    }
}