using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreSystem.ServiceLayer;
using StoreSystem.Shared;
using StoreSystem.Shared.DTOs;

//This is our API controller.
//It receives HTTP requests, uses the IProductService to perform business operations,
//and returns HTTP responses. It uses ApiEndpoints.ProductsBase for consistent routing.
//(Consistency → All routes live in one place (ApiEndpoints class).
//(Maintainability → If you want to change api/products → api/v1/products, you update only one constant instead of every controller.)
namespace StoreSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    //base route (api/products) is stored in a central constants class instead of hardcoding.
    [Route(ApiEndpoints.ProductsBase)] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        //gets all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            //status in response
            return Ok(products);
        }
        //get product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        //Create Product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var response = await _productService.AddProductAsync(createProductDto);
            // var product = await _productService.AddProductAsync(createProductDto);
            
            // return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            return Ok(response);  // sends back Name, Price, and Message
            
        }
        
    }
    
}
