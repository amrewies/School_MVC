using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using School_MVC.ValidationAttibute.CoureValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_MVC.Models
{
   public class Course
   {
      public int Id { get; set; }
      [MinLength(3,ErrorMessage = "Name.length > 3")]
      [MaxLength(10, ErrorMessage = "Name.Length<10")]
      [Unique]
      public required string Name { get; set; }
      [Range(maximum:100,minimum:50,ErrorMessage = "Degree Range Between 50,100")]
      public int Degree { get; set; }
      [Remote("ValidationMinDegree","Course",AdditionalFields = "Degree",ErrorMessage ="MinDegree less than Degree")]
      public int MinDegree { get; set; }

      [ForeignKey("Department")]
      [Display(Name ="Department")]
      public int? DepartmentId { get; set; }
      public virtual Department? Department { get; set; }

      public virtual List<CourseResult>? Courses { get; set; } = new List<CourseResult>();
   }
}
