using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School_MVC.Models;
using School_MVC.Reprostry.AccountRepository;
using School_MVC.Reprostry.CourseReprostry;
using School_MVC.Reprostry.DepartmentReprostry;
using School_MVC.Reprostry.InstructorRepository;
using School_MVC.Reprostry.TraineeReprostry;

namespace School_MVC
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         // Add services to the container.
         builder.Services.AddControllersWithViews();

         builder.Services.AddDbContext<SchoolContext>(options =>
         {
            options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
         });

         builder.Services.AddIdentity<ApplicationIdentityUser, IdentityRole>(options =>
         {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
         })
         .AddEntityFrameworkStores<SchoolContext>();

         builder.Services.AddSession();

         builder.Services.AddScoped<IInstructorGetAllRepository, InstructorGetAllRepository>();
         builder.Services.AddScoped<ITraineeGetByStudentIdAndCourseRepository, TraineeGetByStudentIdAndCourseRepository>();
         builder.Services.AddScoped<ITraineeGetByStudentIdRepository, TraineeGetByStudentIdRepository>();
         builder.Services.AddScoped<ICourseGetByCourseIdRepository, CourseGetByCourseIdRepository>();
         builder.Services.AddScoped<IInstructorGetByCourseIdRepository, InstructorGetByCourseIdRepository>();
         builder.Services.AddScoped<ICourseReprostry, CourseReprostry>();
         builder.Services.AddScoped<IDepartmentReprostry, DepartmentReprostry>();
         builder.Services.AddScoped<IInstructorCRUDOperation, InstructorCRUDOperation>();
         builder.Services.AddScoped<ICourseCRUDOperation, CourseCRUDOperation>();
         builder.Services.AddScoped<IRegistrationAccount, RegistrationAccount>();


         var app = builder.Build();

         // Configure the HTTP request pipeline.
         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
         }
         app.UseStaticFiles();

         app.UseRouting();

         app.UseSession();

         app.UseAuthorization();

         app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");

         app.Run();
      }
   }
}