using Microsoft.EntityFrameworkCore;
using School_MVC.Models;

namespace School_MVC.Reprostry.InstructorRepository
{
   public class InstructorGetByCourseIdRepository: IInstructorGetByCourseIdRepository
   {
      public List<Instructor> GetByCourseId(int courseId)
      {

         using (var context = new SchoolContext())
         {
            return context.Instructors.Include(c => c.Course).Where(i => i.Course.Id == courseId).ToList();
         }
      }
   }
}
