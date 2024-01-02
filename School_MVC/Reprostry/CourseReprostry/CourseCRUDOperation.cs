using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School_MVC.Models;

namespace School_MVC.Reprostry.CourseReprostry
{
   public class CourseCRUDOperation : ICourseCRUDOperation
   {

      public void New(Course course)
      {
         using var Context = new SchoolContext();
         Context.Courses.Add(course);
         Context.SaveChanges();
      }

      public void Edit(Course course)
      {
         
         using var Context = new SchoolContext();
         Context.Courses.Update(course);
         Context.SaveChanges();
      }

      public void Delete(Course course)
      {
         using var Context = new SchoolContext();
         Context.Courses.Remove(course);
         Context.SaveChanges();
      }
   }
}
