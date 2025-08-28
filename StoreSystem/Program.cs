// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using Microsoft.EntityFrameworkCore;
// using StoreSystem.Data;
// using StoreSystem.DataLayer;
// using StoreSystem.ServiceLayer;
// //Program.cs (Dependency Injection and Configuration)
// //set up services
//
// //This is the heart of the backend application startup.
// // It registers StoreDbContext to use an in-memory database.
// // It registers our IProductRepository and ProductRepository for dependency injection. When something asks for IProductRepository, it gets an instance of ProductRepository.
// // It registers our IProductService and ProductService similarly.
// // Crucially, it configures CORS (AllowBlazorClient policy) to allow our Blazor client (which will run on a different port) to make requests to this API. Make sure the origins match your actual client ports.
// // namespace StoreSystem
// // {
//     var builder = WebApplication.CreateBuilder(args);
//     builder.Services.AddControllers();
//     
//     // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//     builder.Services.AddEndpointsApiExplorer();
//     builder.Services.AddSwaggerGen();
//     
//     // Configure DbContext with In-Memory Database
//     builder.Services.AddDbContext<StoreDbContext>(options =>
//         options.UseInMemoryDatabase("StoreSystemDb"));
//     
//     // Register Repositories and Services for Dependency Injection
//     builder.Services.AddScoped<IProductRepository, ProductRepository>();
//     builder.Services.AddScoped<IProductService, ProductService>();
//     
//     //comment out this is CORS (FRONT END SET UP to listen on a certain port)
//     /*
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowBlazorClient",
//         policy =>
//         {
//             policy.WithOrigins("https://localhost:7042", "http://localhost:5042")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//         });
// });
// */
//     
//     var app = builder.Build();
//     
//     // Configure the HTTP request pipeline.
//     if (app.Environment.IsDevelopment())
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI();
//     }
//     
//     app.UseHttpsRedirection(); 
//     
//     //Removed CORS middleware (front end middleware)
// // app.UseCors("AllowBlazorClient");
//
//     app.UseAuthorization();
//     app.MapControllers();
//     app.Run();
//
// // }
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StoreSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
