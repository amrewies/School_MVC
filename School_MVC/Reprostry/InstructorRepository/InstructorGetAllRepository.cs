using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.ViewModels.InstructorModel;
using System;

namespace School_MVC.Reprostry.InstructorRepository
{
   public class InstructorGetAllRepository: IInstructorGetAllRepository
   {
      

      public List<Instructor> GetAll()
      {
         using var context = new SchoolContext();
         return context.Instructors
            .Include(d => d.Department).Include(c => c.Course).ToList();
      }

      public Instructor? GetById(int Id)
      {
         using SchoolContext context = new();
         return context.Instructors
            .Include(d => d.Department).Include(c => c.Course).FirstOrDefault(i => i.Id == Id);
      }

      public Instructor? GetByIdWithoutDepartmentAndCourse(int Id)
      {
         using SchoolContext context = new();
         return context.Instructors.FirstOrDefault(i => i.Id == Id);
      }

   }
}
