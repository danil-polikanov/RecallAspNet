using Microsoft.EntityFrameworkCore;
using RecallAspNet.Models;
using System.Configuration;

namespace RecallAspNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var allServices = builder.Services;
               
            
            builder.Services.AddRazorPages();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddControllersWithViews();
            string computerName = Environment.MachineName;

            if (computerName.ToLower()=="gregor")
            {
                builder.Services.AddDbContext<ApplicationDbContext>
                (option => option.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnection")));           
                Console.WriteLine("Система определила, что вы используете ноутбук.");
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>
                (option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                Console.WriteLine("Система определила, что вы используете компьютер.");
            }
            //LaptopConnection

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}