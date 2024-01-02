using Microsoft.AspNetCore.Mvc;
using School_MVC.Models;
using School_MVC.ViewModels.InstructorModel;

namespace School_MVC.Reprostry.InstructorRepository
{
   public interface IInstructorGetAllRepository
   {
      List<Instructor> GetAll();

      Instructor? GetById(int Id);

      Instructor? GetByIdWithoutDepartmentAndCourse(int Id);

   }
}
