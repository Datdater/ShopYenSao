using ShopYenSao.Application.Models.Payment;

namespace ShopYenSao.Application.Contracts.Service;

public interface IPaymentService
{
    Task<string> CreatePaymentLink(PaymentRequest request);
}