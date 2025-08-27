namespace StoreSystem.Shared;
// This represents the core business entity, often mapping directly to a database table
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}