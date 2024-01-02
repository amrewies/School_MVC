using Microsoft.EntityFrameworkCore;
using School_MVC.Models;

namespace School_MVC.Reprostry.CourseReprostry
{
   public class CourseReprostry : ICourseReprostry
   {
      public List<Course> GetAll()
      {
         using SchoolContext context = new();
         return context.Courses.Include(d=>d.Department).ToList();
      }

      public Course? GetById(int Id)
      {
         using SchoolContext context = new();
         return context.Courses.Include(d => d.Department).FirstOrDefault(c => c.Id == Id);
      }

      public Course?  GetByNameAndDepartmentId(string Name,int DepartmentId)
      {
         using SchoolContext context = new();
         return context.Courses.Include(d => d.Department).FirstOrDefault(c => c.Name == Name && c.DepartmentId== DepartmentId);
      }

      public List<Course> GetByDepartmentId(int DepartmentId)
      {
         using SchoolContext context = new();
         return context.Courses.Where(c=>c.DepartmentId==DepartmentId).ToList();
      }
   }
}
