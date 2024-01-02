using School_MVC.Models;

namespace School_MVC.Reprostry.CourseReprostry
{
   public interface ICourseReprostry
   {
      List<Course> GetAll();
      Course? GetById(int Id);
      Course? GetByNameAndDepartmentId(string Name, int DepartmentId);
      List<Course> GetByDepartmentId(int DepartmentId);
   }
}
