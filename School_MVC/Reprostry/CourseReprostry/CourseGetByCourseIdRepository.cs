using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.ViewModels.CourseModel;
using School_MVC.Reprostry.InstructorRepository;

namespace School_MVC.Reprostry.CourseReprostry
{
   public class CourseGetByCourseIdRepository: ICourseGetByCourseIdRepository
   {
      readonly IInstructorGetByCourseIdRepository _InstructorGetByCourseIdRepository;

      public CourseGetByCourseIdRepository(IInstructorGetByCourseIdRepository _InstructorGetByCourseIdRepository)
      {
         this._InstructorGetByCourseIdRepository = _InstructorGetByCourseIdRepository;
      }
      public List<CourseResult> GetByTraineeId(int CourseId)
      {
         using var context = new SchoolContext();
         return context.CoursesResult
            .Where(cr => cr.CourseId == CourseId)
            .Include(c => c.Course)
            .ThenInclude(t => t.Department)
            .Include(t => t.Trainee)
            .ToList();
      }

      public CourseShowCourseResultModel GetByTraineeIdModel(int CouresId)
      {
         CourseShowCourseResultModel courseShowCourseResultModel = new();
         List<CourseResult> getByTraineeId = GetByTraineeId(CouresId);

         string? CourseName = getByTraineeId.Select(c => c?.Course?.Name).FirstOrDefault();

         if (CourseName != null)
         {
            courseShowCourseResultModel.DepartmentName = getByTraineeId.Select(c => c.Course?.Department?.Name).FirstOrDefault();
            courseShowCourseResultModel.CourseName = CourseName;
            courseShowCourseResultModel.Instructors = _InstructorGetByCourseIdRepository.GetByCourseId(CouresId);


            foreach (CourseResult item in getByTraineeId)
            {
               courseShowCourseResultModel.Degree.Add(item.Degree);
               if (item.Trainee != null)
                  courseShowCourseResultModel.TraineeName.Add(item.Trainee.Name);
               if (item.Course != null)
                  courseShowCourseResultModel.Color.Add(item.Degree < item.Course.MinDegree ? "red" : "green");
            }

         }
         else
         {
            using SchoolContext context = new();

            CourseName = context.Courses?.FirstOrDefault(c => c.Id == CouresId)?.Name;
            courseShowCourseResultModel.CourseName = CourseName;
         }
         return courseShowCourseResultModel;
      }


      public string? GetCourseNameByCoureId(int CouresId)
      {
         List<CourseResult> getByTraineeId = GetByTraineeId(CouresId);
         return getByTraineeId.Select(c => c?.Course?.Name).FirstOrDefault();
      }

      public CourseShowCourseResultModel GetDepartmentNameAndCourseNameByCourseId(int CouresId)
      {
         CourseShowCourseResultModel courseShowCourseResultModel = new();
         List<CourseResult> getByTraineeId = GetByTraineeId(CouresId);
         string? CourseName = GetCourseNameByCoureId(CouresId);
         if (CourseName != null)
         {
            courseShowCourseResultModel.DepartmentName = getByTraineeId.Select(c => c.Course?.Department?.Name).FirstOrDefault();
            courseShowCourseResultModel.CourseName = CourseName;
         }
         return courseShowCourseResultModel;
      }


      public CourseShowCourseResultModel GetDegreeTraineeNameColorByCourseId(int CouresId)
      {
         List<CourseResult> getByTraineeId = GetByTraineeId(CouresId);
         CourseShowCourseResultModel courseShowCourseResultModel = new();
         foreach (CourseResult item in getByTraineeId)
         {
            courseShowCourseResultModel.Degree.Add(item.Degree);
            if (item.Trainee != null)
               courseShowCourseResultModel.TraineeName.Add(item.Trainee.Name);
            if (item.Course != null)
               courseShowCourseResultModel.Color.Add(item.Degree < item.Course.MinDegree ? "red" : "green");
         }

         return courseShowCourseResultModel;
      }

      public CourseShowCourseResultModel GetCourseNameByCourseId(int CouresId)
      {
        CourseShowCourseResultModel courseShowCourseResultModel = new();
         using (var context = new SchoolContext())
         {
            string? CourseName = context.Courses?.FirstOrDefault(c => c.Id == CouresId)?.Name;
            courseShowCourseResultModel.CourseName = CourseName;
         }
         return courseShowCourseResultModel;
      }

   }
}
