using System.Collections.Generic;
using System.Threading.Tasks;
using StoreSystem.Shared.DTOs;
// namespace DefaultNamespace;
//service layer is buisness logic meaning what is returned in the response

namespace StoreSystem.ServiceLayer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto> AddProductAsync(CreateProductDto productDto);
    }
}
