using School_MVC.Models;

namespace School_MVC.Reprostry.CourseReprostry
{
   public interface ICourseCRUDOperation
   {
       void New(Course course);
      void Edit(Course course);
      void Delete(Course course);
   }
}
