namespace School_MVC.ViewModels.TraineeModel
{
   public class TraineeShowTraineeResultModel
   {
      public string? TraineeName { get; set; }
      public string? DepartmentName { get; set; }
      public List<string> CourseName { get; set; } = new List<string>();
      public List<int> Degree { get; set; } = new List<int>();
      public List<string> Color { get; set; } = new List<string>();
   }
}
