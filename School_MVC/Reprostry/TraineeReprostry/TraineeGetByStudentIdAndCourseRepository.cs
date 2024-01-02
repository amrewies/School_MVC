using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.ViewModels.TraineeModel;
using System.Collections.Generic;

namespace School_MVC.Reprostry.TraineeReprostry
{
   public class TraineeGetByStudentIdAndCourseRepository : ITraineeGetByStudentIdAndCourseRepository
   {
      public CourseResult? GetByTraineeIdAndCourse(int TraineetId, int CourseId)
      {
         using(var Context=new SchoolContext())
         {
            return Context.CoursesResult
               .Include(t => t.Trainee).ThenInclude(t=>t.Department).Include(t => t.Course).FirstOrDefault(cr => cr.TraineeId == TraineetId && cr.CourseId == CourseId);
         }
      }
      public TraineeShowResultModel GetByTraineeIdAndCourseModel(int TraineetId, int CourseId)
      {
         TraineeShowResultModel traineeShowResultModel = new TraineeShowResultModel();
         CourseResult? getByTraineetIdAndCourse= GetByTraineeIdAndCourse(TraineetId, CourseId);
         if(getByTraineetIdAndCourse!=null && getByTraineetIdAndCourse.Trainee!=null && getByTraineetIdAndCourse.Course!=null)
         {
            traineeShowResultModel.TraineeName = getByTraineetIdAndCourse.Trainee.Name;
            traineeShowResultModel.CourseName = getByTraineetIdAndCourse.Course.Name;
            traineeShowResultModel.DepartmentName = getByTraineetIdAndCourse.Trainee.Department?.Name;
            traineeShowResultModel.Degree = getByTraineetIdAndCourse.Degree;
            traineeShowResultModel.Color =
               getByTraineetIdAndCourse.Degree< getByTraineetIdAndCourse.Course.MinDegree?"red":"green";
         }
         return traineeShowResultModel;
      }
   }
}
