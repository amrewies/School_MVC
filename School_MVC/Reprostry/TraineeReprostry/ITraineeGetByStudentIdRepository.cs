using School_MVC.Models;
using School_MVC.ViewModels.TraineeModel;

namespace School_MVC.Reprostry.TraineeReprostry
{
   public interface ITraineeGetByStudentIdRepository
   {
      List<CourseResult> GetByTraineeId(int TraineeId);
      TraineeShowTraineeResultModel GetByTraineeIdModel(int TraineeId);
   }
}
