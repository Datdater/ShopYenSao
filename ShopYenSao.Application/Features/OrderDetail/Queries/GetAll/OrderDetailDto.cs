namespace ShopYenSao.Application.Features.OrderDetail.Queries.GetAll;

public class OrderDetailDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}