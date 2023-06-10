using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFoodDelivery.Context;
using MVCFoodDelivery.Models;
using MVCFoodDelivery.Repository;

namespace MVCFoodDelivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IToLoginRepository, ToLoginRepository>();
            var connectionString = builder.Configuration.GetConnectionString("ToLoginDbContext");
            builder.Services.AddDbContext<ToLoginDbContext>(options => options.UseSqlServer(connectionString));

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


            app.Map("/maproute", ([FromServices] IToLoginRepository repository) =>
            {
                return repository.GetAll();
            });


            app.MapGet("/mapget", (
                [FromServices] IToLoginRepository repository) =>
            {
                return repository.GetAll();
            });


            //app.MapPost("/post", (IFormFile file,
            //[FromServices] IToLoginRepository repository) =>
            //{
            //    using var reader = new StreamReader(file.OpenReadStream());

            //    while (reader.Peek() >= 0)
            //        repository.(tologin);

            //});

            app.MapPost("/mappost", () => "For MapPost");

            app.MapPut("/mapput", () => "For MapPut");


            app.MapDelete("/mapdelete", (
            [FromServices] IToLoginRepository repository) =>
            {
                return repository.delete(9);
            });


            //app.UseEndpoints(endpoint =>
            //{
            //    endpoint.MapPost("/mappost", async context =>
            //    {
            //        await context.Response.WriteAsync("Post is working");
            //    });
            //});
            app.Run();
        }
    }
}