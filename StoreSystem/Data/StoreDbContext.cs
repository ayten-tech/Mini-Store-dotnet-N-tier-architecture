using System;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Shared.Models;


//Explanation: This is our Entity Framework Core DbContext.
//It's the bridge between our application and the database.
//DbSet<Product> tells EF Core to manage Product entities.
//OnModelCreating is used to seed some initial data.

//Pattern: Unit of Work (via DbContext) + EF Core configs.

namespace StoreSystem.Data
{
    public class StoreDbContext: DbContext
    {
        //constructor
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        //seed some initial data in database for testing
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "Powerful portable computer", Price = 1200.00M, Stock = 50, CreatedDate = DateTime.UtcNow },
                new Product { Id = 2, Name = "Mouse", Description = "Wireless ergonomic mouse", Price = 25.00M, Stock = 200, CreatedDate = DateTime.UtcNow },
                new Product { Id = 3, Name = "Keyboard", Description = "Mechanical RGB keyboard", Price = 75.00M, Stock = 100, CreatedDate = DateTime.UtcNow }
            );
        }
    }
}
