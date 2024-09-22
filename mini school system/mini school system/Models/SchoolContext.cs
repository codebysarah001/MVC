using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace mini_school_system.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("DefaultConnection")
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Prevent table names from being pluralized (optional)
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        // Seed data for Subjects (Courses)
        public static void Seed(SchoolContext context)
        {
            context.Subjects.AddOrUpdate(
                s => s.Name, // Prevents duplicate seeding
                new Subject { Name = "Mathematics" },
                new Subject { Name = "Science" },
                new Subject { Name = "History" }
            );

            context.SaveChanges(); 
        }

    }
}