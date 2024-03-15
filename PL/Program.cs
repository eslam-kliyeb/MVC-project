using BLL.Repositories;
using BLL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
using Microsoft.Extensions.DependencyInjection;
using PL.MappingProfiles;

namespace PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //-------------------------------------------------------------------------------
            builder.Services.AddDbContext<DataContext>
            (option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
            }
            );
            builder.Services.AddAutoMapper(e=>e.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(d=>d.AddProfile(new DepartmentProfile()));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            //---------------------------------------------------------------------------------
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}