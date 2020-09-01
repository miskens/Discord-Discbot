using Microsoft.EntityFrameworkCore;
using MiskDiscBot.DAL.Models.Discs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiskDiscBot.DAL
{
    public class DiscGolfContext: DbContext
    {
        public DiscGolfContext(DbContextOptions<DiscGolfContext> options): base(options) { }

        //public DBSet<Brands> Brands { get; set; }
        // public DBSet<Courses> Course { get; set; }
        public DbSet<Disc> Discs { get; set; }
    }
}
