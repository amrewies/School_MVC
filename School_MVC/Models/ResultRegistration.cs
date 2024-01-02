using Microsoft.AspNetCore.Identity;

namespace School_MVC.Models
{
   public class ResultRegistration
   {
      public required IdentityResult IdentityResult { get; set; }
      public required ApplicationIdentityUser UserModel { get; set; }
   }
}
