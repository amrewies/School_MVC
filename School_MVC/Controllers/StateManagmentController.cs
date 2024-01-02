using Microsoft.AspNetCore.Mvc;

namespace School_MVC.Controllers
{
   public class StateManagmentController : Controller
   {
      public IActionResult SaveSession()
      {
         HttpContext.Session.SetString("UserName", "AmrEwies");
         HttpContext.Session.SetInt32("Password", 01028190342);
         return Content("Saved Data");
      }

      public IActionResult GetSession()
      {
         string? UserName= HttpContext.Session.GetString("UserName");
         int? Password=HttpContext.Session.GetInt32("Password");
         if (UserName != null && Password != null)
            return Content($"UserName={UserName} Password={Password}");
         return Content("");
      }

      public IActionResult SaveCookie()
      {
         HttpContext.Response.Cookies.Append("Cart1", "Iphone 11");
         HttpContext.Response.Cookies.Append("Cart2", "Iphone 14");
         return Content("Saved Data");
      }

      public IActionResult GetCookie()
      {
         string? Cart1 = HttpContext.Request.Cookies["Cart1"];
         string? Cart2 = HttpContext.Request.Cookies["Cart2"];
         if (Cart1 != null && Cart2 != null)
            return Content($"Cart1={Cart1} Cart2={Cart2}");
         return Content("");
      }

      public IActionResult First()
      {
         TempData["Info"] = "Hello World";
         return Content("Saved Data");
      }

      public IActionResult Second()
      {
         string? Info= TempData["Info"]?.ToString();
         if (Info != null)
            return Content($"{Info}");
         return Content("");
      }

      public IActionResult Third()
      {
         string? Info = TempData?.Peek("Info")?.ToString();
         if (Info != null)
            return Content($"{Info}");
         return Content("");
      }

      public IActionResult Fourth()
      {
         string? Info = TempData["Info"]?.ToString();
         if(Info != null)
         {
            TempData.Keep("Info");
            return Content($"{Info}");
         }
         return Content("");
      }
   }
}
