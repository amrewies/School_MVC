using School_MVC.Models;

namespace School_MVC.Reprostry.DepartmentReprostry
{
   public class DepartmentReprostry : IDepartmentReprostry
   {
      public List<Department> GetAll()
      {
         using SchoolContext context = new();
         return context.Departments.ToList();
      }
   }
}
