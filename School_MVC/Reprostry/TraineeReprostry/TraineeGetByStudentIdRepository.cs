using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.ViewModels.CourseModel;
using School_MVC.ViewModels.TraineeModel;

namespace School_MVC.Reprostry.TraineeReprostry
{
   public class TraineeGetByStudentIdRepository: ITraineeGetByStudentIdRepository
   {
      public List<CourseResult> GetByTraineeId(int TraineeId)
      {
         using(var context=new SchoolContext())
         {
            return context.CoursesResult
               .Where(cr=>cr.TraineeId == TraineeId)
               .Include(t=>t.Trainee)
               .Include(c=>c.Course)
               .ToList();
         }
      }


      public TraineeShowTraineeResultModel GetByTraineeIdModel(int TraineeId)
      {
         TraineeShowTraineeResultModel traineeShowTraineeResultModel = new();
         List<CourseResult> getByTraineeId = GetByTraineeId(TraineeId);
         
         string? TraineeName = getByTraineeId.Select(t => t?.Trainee?.Name).FirstOrDefault();
         if (TraineeName != null)
         {
            traineeShowTraineeResultModel.TraineeName = TraineeName;
            foreach (var item in getByTraineeId)
            {
               traineeShowTraineeResultModel.Degree.Add(item.Degree);
               if (item.Course != null)
               {
                  traineeShowTraineeResultModel.CourseName.Add(item.Course.Name);
                  traineeShowTraineeResultModel.Color.Add(item.Degree < item.Course.MinDegree ? "red" : "green");
               }
            }
         }
         else
         {
            using (var context = new SchoolContext())
            {
               Trainee? trainee = context.Trainees.Include(d=>d.Department).FirstOrDefault(t => t.Id == TraineeId);
               traineeShowTraineeResultModel.TraineeName = trainee?.Name;
               traineeShowTraineeResultModel.DepartmentName = trainee?.Department?.Name;
               
            }
         }
         
         return traineeShowTraineeResultModel;
      }

   }
}
