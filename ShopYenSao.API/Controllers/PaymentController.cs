using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopYenSao.Application.Contracts.Service;

namespace ShopYenSao.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPaymentService _paymentService;
    
    public PaymentController(IMediator mediator, IPaymentService paymentService)
    {
        _mediator = mediator;
        _paymentService = paymentService;
    }
}