using Microsoft.EntityFrameworkCore;

namespace ShopYenSao.Domain;

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Version { get; set; }
    public DateTime ExpiryDate { get; set; }
}