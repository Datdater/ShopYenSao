using ShopYenSao.Application.Features.Category.Commands.GetAllCategory;

namespace ShopYenSao.Application.Features.Product.Queries.GetById;

public class ProductDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public CategoryDto Category { get; set; }
    public string Version { get; set; }
    public DateTime ExpiryDate { get; set; }
}