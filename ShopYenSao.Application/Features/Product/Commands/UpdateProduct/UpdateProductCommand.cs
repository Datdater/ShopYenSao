using MediatR;

namespace ShopYenSao.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public string Version { get; set; }
    public DateTime ExpiryDate { get; set; }
}