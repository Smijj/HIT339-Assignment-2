using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssignmentOne_CYCC.Models;
using AssignmentOne_CYCC.ViewModels;

namespace AssignmentOne_CYCC.Data
{
    public class AssignmentOne_CYCCContext : DbContext
    {
        public AssignmentOne_CYCCContext (DbContextOptions<AssignmentOne_CYCCContext> options)
            : base(options)
        {
        }

        public DbSet<AssignmentOne_CYCC.Models.Students> Students { get; set; }

        public DbSet<AssignmentOne_CYCC.Models.Instrument> Instrument { get; set; }

        public DbSet<AssignmentOne_CYCC.Models.Tutor> Tutor { get; set; }

        public DbSet<AssignmentOne_CYCC.Models.Duration> Duration { get; set; }

        public DbSet<AssignmentOne_CYCC.Models.Lesson> Lesson { get; set; }

        public DbSet<AssignmentOne_CYCC.Models.Invoice> Invoice { get; set; }

        public DbSet<AssignmentOne_CYCC.ViewModels.LessonViewModel> lessonViewModel { get; set; }
    }
}
