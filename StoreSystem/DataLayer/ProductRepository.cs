using Microsoft.EntityFrameworkCore;
using StoreSystem.Data;
using StoreSystem.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace StoreSystem.DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;
        //constructor initializing dbcontext
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
