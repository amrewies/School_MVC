using School_MVC.Models;
using School_MVC.ViewModels.TraineeModel;

namespace School_MVC.Reprostry.TraineeReprostry
{
   public interface ITraineeGetByStudentIdAndCourseRepository
   {
      CourseResult? GetByTraineeIdAndCourse(int TraineetId, int CourseId);
      TraineeShowResultModel GetByTraineeIdAndCourseModel(int TraineetId, int CourseId);
   }
}
