using School_MVC.Models;

namespace School_MVC.Reprostry.InstructorRepository
{
   public interface IInstructorCRUDOperation
   {
      void New(Instructor instructor);

      void Update(Instructor instructor);
      void Delete(Instructor instructor);
   }
}
