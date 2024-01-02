using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace School_MVC.Models
{
   public class SchoolContext:IdentityDbContext<ApplicationIdentityUser>   
   {
      public SchoolContext() : base()
      {

      }

      public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
      public virtual DbSet<Department> Departments { get; set; }
      public virtual DbSet<Instructor> Instructors { get; set; }
      public virtual DbSet<Trainee> Trainees { get; set; }
      public virtual DbSet<Course> Courses { get; set; }
      public virtual DbSet<CourseResult> CoursesResult { get; set; }
      
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=School;Integrated Security=True;Encrypt=False");
      }
      
   }
}
