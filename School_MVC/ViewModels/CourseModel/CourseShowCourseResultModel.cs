using School_MVC.Models;

namespace School_MVC.ViewModels.CourseModel
{
   public class CourseShowCourseResultModel
   {
      public string? CourseName { get; set; }
      public string? DepartmentName { get; set; }
      public List<string> TraineeName { get; set; } = new List<string>();
      public List<int> Degree { get; set; } = new List<int>();
      public List<string> Color { get; set; } = new List<string>();
      public List<Instructor> Instructors { get; set; } = new List<Instructor>();

   }
}
