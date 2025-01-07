using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopYenSao.Application.Contracts.Service;
using ShopYenSao.Application.Features.Payment.Commands.CreatePayment;
using ShopYenSao.Application.Features.Payment.Commands.UpdatePayment;
using ShopYenSao.Application.Features.Payment.Queries.GetById;
using ShopYenSao.Application.Models.Payment;

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
    [HttpPost]
    public async Task<IActionResult> Post(CreatePaymentCommand request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtRoute("GetPaymentById", new { id = response });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePaymentCommand updatePaymentCommand)
    {
        var response = await _mediator.Send(updatePaymentCommand);
        return CreatedAtRoute("GetPaymentById", new { id = response });
    }

    [HttpGet("{id}", Name = "GetPaymentById")]
    public async Task<PaymentDto> GetById([FromRoute]GetPaymentByIdQuery id)
    {
        var payment = await _mediator.Send(id);
        return payment;
    }

    [HttpPost("/create-payment-link")]
    public async Task<string> CreatePaymentLink(PaymentRequest request)
    {
        var paymentLink = await _paymentService.CreatePaymentLink(request);
        return paymentLink;
    }
}