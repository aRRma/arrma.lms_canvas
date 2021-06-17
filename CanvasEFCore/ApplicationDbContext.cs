using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasEFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CanvasEFCore
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<LmsCourse> Courses { get; set; }
        public DbSet<LmsStudent> Students { get; set; }
        public DbSet<LmsTeacher> Teachers { get; set; }
        public DbSet<LmsAssignmentGroup> AssignmentGroups { get; set; }
        public DbSet<LmsAssignment> Assignments { get; set; }
        public DbSet<LmsSubmission> Submissions { get; set; }
        public DbSet<LmsAttachment> Attachments { get; set; }

        public ApplicationDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = canvas.db");
        }
    }
}
