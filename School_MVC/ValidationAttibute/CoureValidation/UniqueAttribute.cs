using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.Reprostry.CourseReprostry;
using System.ComponentModel.DataAnnotations;

namespace School_MVC.ValidationAttibute.CoureValidation
{
   public class UniqueAttribute : ValidationAttribute
   {
      /*
      ICourseReprostry _CourseReprostry;
      public UniqueAttribute(ICourseReprostry _CourseReprostry)
      {
         this._CourseReprostry = _CourseReprostry;
      }
      */
      public override bool IsValid(object? value)
      {
         return base.IsValid(value);
      }
      protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
      {
         string? Name = value?.ToString();
         if(Name!=null)
         {
            Course coure =(Course) validationContext.ObjectInstance;
            using SchoolContext context = new();
            Course? courseFromDatabase =context.Courses
               .FirstOrDefault(c => c.Name == Name &&c.DepartmentId == coure.DepartmentId);
            //Course? courseFromDatabase = _CourseReprostry.GetByNameAndDepartmentId(Name, CourseFromDatabase.Id);
            if(courseFromDatabase==null || courseFromDatabase.Id== coure.Id)
               return ValidationResult.Success;
            
            return new ValidationResult("Name Is Already Found");
         }
         return ValidationResult.Success;
      }
   }
}
