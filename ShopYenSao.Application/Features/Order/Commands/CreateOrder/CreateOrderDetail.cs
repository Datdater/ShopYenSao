namespace ShopYenSao.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderDetail
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}