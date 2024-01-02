using School_MVC.Models;
using School_MVC.ViewModels.CourseModel;
using School_MVC.ViewModels.TraineeModel;

namespace School_MVC.Reprostry.CourseReprostry
{
   public interface ICourseGetByCourseIdRepository
   {
      List<CourseResult> GetByTraineeId(int CouresId);
      CourseShowCourseResultModel GetByTraineeIdModel(int CouresId);
   }
}
