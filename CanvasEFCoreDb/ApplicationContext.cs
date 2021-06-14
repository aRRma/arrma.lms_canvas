using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasEFCoreDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace CanvasEFCoreDb
{
    class ApplicationContext : DbContext
    {
        public DbSet<LmsCourse> Courses { get; set; }
        public DbSet<LmsTeacher> Teachers { get; set; }
        public DbSet<LmsStudent> Students { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = canvas.db");
        }
    }
}
