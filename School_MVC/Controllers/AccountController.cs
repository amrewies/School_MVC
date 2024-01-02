using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School_MVC.Models;
using School_MVC.Reprostry.AccountRepository;
using School_MVC.ViewModels.Identity;

namespace School_MVC.Controllers
{
   public class AccountController : Controller
   {
      private readonly UserManager<ApplicationIdentityUser> userManager;
      private readonly SignInManager<ApplicationIdentityUser> signInManager;
      private readonly IRegistrationAccount _RegistrationAccount;

      public AccountController(UserManager<ApplicationIdentityUser> userManager,
         SignInManager<ApplicationIdentityUser> signInManager,
         IRegistrationAccount _RegistrationAccount)
      {
         this.userManager = userManager;
         this.signInManager = signInManager;
         this._RegistrationAccount = _RegistrationAccount;
      }
      [HttpGet]
      public IActionResult Registration()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Registration(RegistrationViewModel registrationViewModel)
      {
         if(ModelState.IsValid)
         {
            ResultRegistration resultRegistration= await _RegistrationAccount.Registration(registrationViewModel);
            if (resultRegistration.IdentityResult.Succeeded)
            {
               await _RegistrationAccount.SignIn(resultRegistration.UserModel,false);
               return RedirectToAction("Index", "Instructor");
            }
         }
         return View(registrationViewModel);
      }

      [HttpGet]
      public IActionResult Login()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Login(LoginViewModel loginViewModel)
      {
         if (ModelState.IsValid)
         {
            ApplicationIdentityUser? user=
               await userManager.FindByNameAsync(loginViewModel.UserName);
            if(user!=null)
            {
               bool Found= await userManager.CheckPasswordAsync(user, loginViewModel.Password);
               if (Found)
               {
                  await signInManager.SignInAsync(user, loginViewModel.RemeberMe);
                  return RedirectToAction("Index", "Instructor");
               }
               ModelState.AddModelError("", "UserName Or Password InCorrect");
            }
         }
         return View(loginViewModel);
      }

      public new async Task<IActionResult> SignOut()
      {
         await signInManager.SignOutAsync();
         return RedirectToAction("Login");
      }
   }
}
