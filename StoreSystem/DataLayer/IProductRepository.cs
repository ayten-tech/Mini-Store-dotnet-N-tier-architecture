using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSystem.Shared.Models;


//In Store System Project (Backend) we're mirroring the layered architecture from the original project(shared)

//DataLayer/
//DEFINING FUNCTIONS RELATED TO CRUD OPERATIONS 
//Holds repositories and interfaces.
//Pattern used: Repository Pattern → abstracts database access from the rest of the app.
namespace StoreSystem.DataLayer
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
    
        //update and delete later 
    
    }
}
