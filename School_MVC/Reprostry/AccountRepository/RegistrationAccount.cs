using Microsoft.AspNetCore.Identity;
using School_MVC.Models;
using School_MVC.ViewModels.Identity;

namespace School_MVC.Reprostry.AccountRepository
{
   public class RegistrationAccount: IRegistrationAccount
   {
      private readonly UserManager<ApplicationIdentityUser> userManager;
      private readonly SignInManager<ApplicationIdentityUser> signInManager;
      public RegistrationAccount(UserManager<ApplicationIdentityUser> userManager,
         SignInManager<ApplicationIdentityUser> signInManager) {
         this.userManager = userManager;
         this.signInManager = signInManager;
      }

      public async Task<ResultRegistration> Registration(RegistrationViewModel registrationViewModel)
      {
         
         ApplicationIdentityUser ModelUser = new();
         ModelUser.UserName = registrationViewModel.UserName;
         ModelUser.PasswordHash = registrationViewModel.Password;
         ModelUser.Address = registrationViewModel.Address;
         IdentityResult identityResult= await userManager.CreateAsync(ModelUser, registrationViewModel.Password);
         ResultRegistration result = new()
         {
            IdentityResult = identityResult,
            UserModel = ModelUser,
         };
         return result;
      }


      public async Task SignIn(ApplicationIdentityUser ModelUser,bool RememberMe)
      {
         await signInManager.SignInAsync(ModelUser, RememberMe);
      }
   }
}
