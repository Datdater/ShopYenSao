using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopYenSao.Application.Contracts.Service;
using ShopYenSao.Application.Models.Payment;
using ShopYenSao.PayOS.Services;

namespace ShopYenSao.PayOS;

public static class DependencyInjection
{
    public static IServiceCollection AddPayOS(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.Configure<PaymentConfig>(configuration.GetSection("PayOS"));
        Net.payOS.PayOS payOS = new Net.payOS.PayOS(configuration["PayOS:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
            configuration["PayOS:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
            configuration["PayOS:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));
        services.AddSingleton(payOS);
        services.AddTransient<IPaymentService, PaymentService>();
        return services;
    }
}