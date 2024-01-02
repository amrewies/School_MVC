using Microsoft.AspNetCore.Identity;

namespace School_MVC.Models
{
   public class ApplicationIdentityUser:IdentityUser
   {
      public string? Address { get; set; }
   }
}
