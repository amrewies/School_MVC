namespace School_MVC.ViewModels.InstructorModel
{
   public class InstructorModel
   {
      public int? Id { get; set; }
      public string? Name { get; set; }
      public int? Salary { get; set; }
      public string? Addrss { get; set; }
      public string? Image { get; set; }
      public int? DepartmentId { get; set; }
      public string? DepartmentName { get; set; }

      public int? CourseId { get; set; }
      public string? CourseName { get; set; }
   }
}
