using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreSystem.DataLayer;
using StoreSystem.ServiceLayer;
using StoreSystem.Shared.Models;
using StoreSystem.Shared.DTOs;
// namespace DefaultNamespace;

namespace StoreSystem.ServiceLayer
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        //buisness logic returns when getting all products first validate Using DTO,
        //then return the following attriibbutes
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    
        public async Task<ProductDto> AddProductAsync(CreateProductDto productDto)
        {
            var newProduct = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CreatedDate = DateTime.UtcNow // Set creation date
            };

            var addedProduct = await _productRepository.AddProductAsync(newProduct);

            return new ProductDto
            {
                Id = addedProduct.Id,
                Name = addedProduct.Name,
                Description = addedProduct.Description,
                Price = addedProduct.Price,
                Stock = addedProduct.Stock
            };
            
        }

    }   
}
