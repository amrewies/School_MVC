using Microsoft.AspNetCore.Mvc;
using School_MVC.Models;
using School_MVC.Reprostry.CourseReprostry;
using School_MVC.Reprostry.DepartmentReprostry;
using School_MVC.ViewModels.CourseModel;

namespace School_MVC.Controllers
{
   public class CourseController : Controller
   {
      readonly ICourseGetByCourseIdRepository _CourseGetByCourseIdRepository;
      readonly ICourseReprostry _CourseReprostry;
      readonly IDepartmentReprostry _DepartmentReprostry;
      readonly ICourseCRUDOperation _CourseCRUDOperation;

      public CourseController(ICourseGetByCourseIdRepository _CourseGetByCourseIdRepository,
			ICourseReprostry _CourseReprostry,
         IDepartmentReprostry _DepartmentReprostry, ICourseCRUDOperation _CourseCRUDOperation)
      {
         this._CourseGetByCourseIdRepository = _CourseGetByCourseIdRepository;
         this._CourseReprostry = _CourseReprostry;
         this._DepartmentReprostry = _DepartmentReprostry;
         this._CourseCRUDOperation = _CourseCRUDOperation;

      }

      public IActionResult Index()
      {
         List<Course> Courses = _CourseReprostry.GetAll();

			return View(Courses);
      }

      public IActionResult Details(int Id)
      {
         Course? Course = _CourseReprostry.GetById(Id);
         return View(Course);
      }

      [HttpGet]
      public IActionResult New()
      {
         ViewBag.Departments = _DepartmentReprostry.GetAll();
         return View();
      }

      [HttpPost]
      public IActionResult New(Course Course)
      {
         if(ModelState.IsValid==true)
         {
            try
            {

               _CourseCRUDOperation.New(Course);
               return RedirectToAction("Index");
            }
            catch(Exception)
            {
               ModelState.AddModelError("DepartmentId", "Select Department");
            }
         }
         ViewBag.Departments = _DepartmentReprostry.GetAll();

         return View(Course);
      }

      [HttpGet]
      public IActionResult Edit(int Id)
      {

         ViewBag.Departments = _DepartmentReprostry.GetAll();
         Course? course=_CourseReprostry.GetById(Id);
         return View(course);
      }
      [HttpPost]
      public IActionResult Edit(Course course)
      {
         if(ModelState.IsValid==true)
         {
            try
            {
               _CourseCRUDOperation.Edit(course);
               return RedirectToAction("Index");
            }catch(Exception)
            {
               ModelState.AddModelError("DepartmentId", "Select Department");
            }
         }
         ViewBag.Departments = _DepartmentReprostry.GetAll();
         return View(course);
      }


      public IActionResult Delete(Course course)
      {
         _CourseCRUDOperation.Delete(course);
         return RedirectToAction("Index");
      }

      public IActionResult ShowCourseResult(int CourseId)
      {
         CourseShowCourseResultModel courseShowCourseResultModel= _CourseGetByCourseIdRepository.GetByTraineeIdModel(CourseId);
         return View(courseShowCourseResultModel);
      }

      public IActionResult ValidationMinDegree(int MinDegree,int Degree)
      {
         if (MinDegree > Degree)
            return Json(false);
         return Json(true);
      }
   }
}
