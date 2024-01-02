using Microsoft.AspNetCore.Identity;
using School_MVC.Models;
using School_MVC.ViewModels.Identity;

namespace School_MVC.Reprostry.AccountRepository
{
   public interface IRegistrationAccount
   {
      Task<ResultRegistration> Registration(RegistrationViewModel registrationViewModel);
      Task SignIn(ApplicationIdentityUser ModelUser, bool RememberMe);
   }
}
