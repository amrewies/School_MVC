using System.ComponentModel.DataAnnotations.Schema;

namespace School_MVC.Models
{
   public class Instructor
   {
      public int Id { get; set; }
      public required string Name { get; set; }
      public int Salary { get; set; }
      public required string Addrss { get; set; }

      public required string Image { get; set; }

      [ForeignKey("Department")]
      public int? DepartmentId { get; set; }
      public virtual Department? Department { get; set; }

      [ForeignKey("Course")]
      public int? CourseId { get; set; }
      public virtual Course? Course { get; set; }
   }
}
