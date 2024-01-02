using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.Reprostry.CourseReprostry;
using School_MVC.Reprostry.DepartmentReprostry;
using School_MVC.Reprostry.InstructorRepository;

namespace School_MVC.Controllers
{
   public class InstructorController : Controller
   {
      readonly IInstructorGetAllRepository _InstructorGetAllRepository;
      readonly IDepartmentReprostry _DepartmentReprostry;
      readonly ICourseReprostry _CourseReprostry;
      readonly IInstructorCRUDOperation _InstructorCRUDOperation;
      public InstructorController(IInstructorGetAllRepository _InstructorGetAllRepository, 
         IDepartmentReprostry _DepartmentReprostry,
         ICourseReprostry _CourseReprostry,
         IInstructorCRUDOperation _InstructorCRUDOperation)
      {
         this._InstructorGetAllRepository = _InstructorGetAllRepository;
         this._DepartmentReprostry = _DepartmentReprostry;
         this._CourseReprostry = _CourseReprostry;
         this._InstructorCRUDOperation = _InstructorCRUDOperation;
      }
      [Authorize]
      public IActionResult Index()
      {
         List<Instructor> instructors = _InstructorGetAllRepository.GetAll();
         return View(instructors);
      }

      public IActionResult DetailsAjax(int Id)
      {
         return PartialView(_InstructorGetAllRepository.GetById(Id));
      }

      public IActionResult Details(int Id)
      {
         Instructor? instructor = _InstructorGetAllRepository.GetById(Id);

         return View(instructor);
      }
      [HttpGet]
      public IActionResult New()
      {
         ViewBag.Departments = _DepartmentReprostry.GetAll();
         ViewBag.Courses = _CourseReprostry.GetAll();
         return View();
      }

      public IActionResult NewAjax(int DepartmentId)
      {
         return Json(_CourseReprostry.GetByDepartmentId(DepartmentId));
      }
      [HttpPost]
      public IActionResult New(Instructor instructor)
      {
         if(instructor.Name!=null && instructor.Salary!=0 && instructor.Addrss!=null && instructor.Image!=null)
         {
            _InstructorCRUDOperation.New(instructor);
            return RedirectToAction("Index");
         }
         ViewBag.Departments = _DepartmentReprostry.GetAll();
         ViewBag.Courses = _CourseReprostry.GetAll();
         return View(instructor);
      }
      [HttpGet]
      public IActionResult Edit(int InstrucotrId)
      {
         ViewBag.Departments = _DepartmentReprostry.GetAll();
         ViewBag.Courses = _CourseReprostry.GetAll();
         Instructor? instructor;
         using (var context=new SchoolContext())
         {
            instructor = _InstructorGetAllRepository.GetByIdWithoutDepartmentAndCourse(InstrucotrId);
         }

         return View(instructor);
      }
      [HttpPost]
      public IActionResult Edit(Instructor instructor)
      {
         if (instructor.Name != null && instructor.Salary != 0 && instructor.Addrss != null && instructor.Image != null)
         {
            _InstructorCRUDOperation.Update(instructor);
            return RedirectToAction("Index");
         }
            ViewBag.Departments = _DepartmentReprostry.GetAll();
            ViewBag.Courses = _CourseReprostry.GetAll();
         return View(instructor);
      }
      
      public IActionResult Delete(int InstrucotrId) 
      {
         Instructor? instructor = _InstructorGetAllRepository.GetByIdWithoutDepartmentAndCourse(InstrucotrId);
         if(instructor != null)
         {
            _InstructorCRUDOperation.Delete(instructor);
         }
         return RedirectToAction("Index");

      }
   }
}
