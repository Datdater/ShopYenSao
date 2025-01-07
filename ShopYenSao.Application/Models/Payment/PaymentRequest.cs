using ShopYenSao.Application.Features.Order.Queries.GetAll;
using ShopYenSao.Application.Features.OrderDetail.Queries.GetAll;

namespace ShopYenSao.Application.Models.Payment;

public class PaymentRequest
{
    public string OrderCode { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}