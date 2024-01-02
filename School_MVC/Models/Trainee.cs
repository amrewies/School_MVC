using System.ComponentModel.DataAnnotations.Schema;

namespace School_MVC.Models
{
   public class Trainee
   {
      public int Id { get; set; }
      public required string Name { get; set; }
      public required string Address { get; set; }
      public required string Grade { get; set; }
      public required string Image { get; set; }

      [ForeignKey("Department")]
      public int? DepartmentId { get; set; }
      public virtual Department? Department { get; set; }
      public virtual List<CourseResult>? Courses { get; set; } = new List<CourseResult>();
   }
}
