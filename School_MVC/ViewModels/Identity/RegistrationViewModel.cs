using System.ComponentModel.DataAnnotations;

namespace School_MVC.ViewModels.Identity
{
   public class RegistrationViewModel
   {
      public required string UserName { get; set; }
      [DataType(DataType.Password)]
      public required string Password { get; set; }
      [DataType(DataType.Password)]
      [Compare("Password")]
      public required string ConfirmPassword { get; set; }
      public required string Address { get; set; }

   }
}
