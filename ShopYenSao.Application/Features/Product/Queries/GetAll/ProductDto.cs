using ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

namespace ShopYenSao.Application.Features.Product.Queries.GetAll;

public class ProductDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public CategoryDto Category { get; set; }
    public string Version { get; set; }
    public DateTime ExpiryDate { get; set; }
}