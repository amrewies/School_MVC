using Microsoft.AspNetCore.Mvc;
using School_MVC.Models;
using School_MVC.Reprostry.TraineeReprostry;
using School_MVC.ViewModels.TraineeModel;

namespace School_MVC.Controllers
{
   public class TraineeController : Controller
   {
      readonly ITraineeGetByStudentIdAndCourseRepository _traineeGetByStudentIdAndCourseRepository;
      readonly ITraineeGetByStudentIdRepository _traineeGetByStudentIdRepository;
      public TraineeController(ITraineeGetByStudentIdAndCourseRepository _traineeGetByStudentIdAndCourseRepository,
         ITraineeGetByStudentIdRepository _traineeGetByStudentIdRepository)
      {
         this._traineeGetByStudentIdAndCourseRepository = _traineeGetByStudentIdAndCourseRepository;
         this._traineeGetByStudentIdRepository = _traineeGetByStudentIdRepository;
      }
      public IActionResult ShowResult(int TraineeId,int CourseId)
      {
        TraineeShowResultModel traineeShowResultModel= _traineeGetByStudentIdAndCourseRepository.GetByTraineeIdAndCourseModel(TraineeId, CourseId);
         return View(traineeShowResultModel);
      }

      public IActionResult ShowTraineeResult(int TraineeId)
      {
         TraineeShowTraineeResultModel traineeShowTraineeResultModel = _traineeGetByStudentIdRepository.GetByTraineeIdModel(TraineeId);
         return View(traineeShowTraineeResultModel);
      }
   }
}
