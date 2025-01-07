using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Net.payOS.Types;
using ShopYenSao.Application.Contracts.Service;
using ShopYenSao.Application.Models.Payment;

namespace ShopYenSao.PayOS.Services;

public class PaymentService : IPaymentService
{
    private readonly Net.payOS.PayOS _payOS;
    private readonly PaymentConfig _paymentConfig;
    public PaymentService(Net.payOS.PayOS payOS, IOptions<PaymentConfig> configuration)
    {
        _payOS = payOS;
        _paymentConfig = configuration.Value;
    }

    public async Task<string> CreatePaymentLink(PaymentRequest request)
    {
        int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
        PaymentData paymentData = new PaymentData(orderCode, (int)request.Amount, request.OrderCode, null, _paymentConfig.CancelUrl, _paymentConfig.ReturnUrl);
        CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);
        return createPayment.checkoutUrl;
    }
}