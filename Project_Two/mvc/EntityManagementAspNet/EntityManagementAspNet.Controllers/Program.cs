using EntityManagementAspNet.Business.Impl;
using EntityManagementAspNet.Business.Service;
using EntityManagementAspNet.DataAccess.Abstract;
using EntityManagementAspNet.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityManagementAspNet.Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPersonService, PersonServiceImpl>();
            builder.Services.AddScoped<IPersonDal, EfPersonDal>();
            builder.Services.AddScoped<IWebOperationService, WebOperationServiceImpl>();
            builder.Services.AddScoped<IWebServiceOperationDal, EfWebServiceOperation>();
            builder.Services.AddDbContext<MyContext>();
            
            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowVueApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            
            // Use CORS
            app.UseCors("AllowVueApp");

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            // dotnet ef migrations add InitialCreate
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MyContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error: Create DB");
                }
            }

            app.Run();
        }
    }
}
