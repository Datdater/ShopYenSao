using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopYenSao.Application.Features.Order.Commands.CreateOrder;
using ShopYenSao.Application.Features.Order.Queries.GetById;
using ShopYenSao.Application.Features.Product.Queries.GetAll;

namespace ShopYenSao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator) => _mediator = mediator;

    
    /// <summary>
    /// Creates an order.
    /// </summary>
    /// <param name="createOrderCommand">The create order command.</param>
    /// <returns>The created order.</returns>
    [HttpPost]
    public async Task<ActionResult> Post(CreateOrderCommand createOrderCommand)
    {
        var response = await _mediator.Send(createOrderCommand);
        
        return CreatedAtRoute("GetOrderById", new { id = response });
    }
    
    [HttpGet("id", Name = "GetOrderById")]
    public async Task<ActionResult> Get([FromQuery]GetOrderSpecificQuery command)
    {
        try
        {
            var response = await _mediator.Send(command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Ok(await _mediator.Send(command));
    }
}