using System.ComponentModel.DataAnnotations;

namespace School_MVC.ViewModels.Identity
{
   public class LoginViewModel
   {
      public required string UserName { get; set; }
      [DataType(DataType.Password)]
      public required string Password { get; set; }
      public bool RemeberMe { get; set; }
   }
}
