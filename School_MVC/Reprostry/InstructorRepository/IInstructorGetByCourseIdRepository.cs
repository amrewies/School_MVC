using School_MVC.Models;

namespace School_MVC.Reprostry.InstructorRepository
{
   public interface IInstructorGetByCourseIdRepository
   {
      List<Instructor> GetByCourseId(int courseId);
   }
}
