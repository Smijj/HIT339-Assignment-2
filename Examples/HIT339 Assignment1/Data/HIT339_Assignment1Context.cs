using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HIT339_Assignment1.Models;

namespace HIT339_Assignment1.Data
{
    public class HIT339_Assignment1Context : DbContext
    {
        public HIT339_Assignment1Context (DbContextOptions<HIT339_Assignment1Context> options)
            : base(options)
        {
        }

        public DbSet<HIT339_Assignment1.Models.Student> Student { get; set; }

        public DbSet<HIT339_Assignment1.Models.Duration> Duration { get; set; }

        public DbSet<HIT339_Assignment1.Models.Tutor> Tutor { get; set; }

        public DbSet<HIT339_Assignment1.Models.Instrument> Instrument { get; set; }

        public DbSet<HIT339_Assignment1.Models.Lesson> Lesson { get; set; }

        public DbSet<HIT339_Assignment1.Models.Letter> Letter { get; set; }
    }
}
