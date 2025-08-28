// namespace StoreSystem.Shared;

//DTO defines define the shape of data sent between the client and server. 
//ProductDto is for displaying product information
//, while CreateProductDto is for the data needed when creating a new product (no Id yet).
namespace StoreSystem.Shared.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

