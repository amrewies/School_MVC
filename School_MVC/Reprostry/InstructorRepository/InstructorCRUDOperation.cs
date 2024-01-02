using School_MVC.Models;

namespace School_MVC.Reprostry.InstructorRepository
{
   public class InstructorCRUDOperation: IInstructorCRUDOperation
   {
      public void New(Instructor instructor)
      {
         using var context = new SchoolContext();
         context.Instructors.Add(instructor);
         context.SaveChanges();
      }

      public void Update(Instructor instructor)
      {
         using var context = new SchoolContext();
         context.Instructors.Update(instructor);
         context.SaveChanges();
      }

      public void Delete(Instructor instructor)
      {
         using var context = new SchoolContext();
         context.Instructors.Remove(instructor);
         context.SaveChanges();
      }
   }
}
