using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopYenSao.Application.Commons;
using ShopYenSao.Application.Features.Product.Commands.CreateProduct;
using ShopYenSao.Application.Features.Product.Commands.UpdateProduct;
using ShopYenSao.Application.Features.Product.Queries.GetAll;
using ShopYenSao.Application.Features.Product.Queries.GetById;

namespace ShopYenSao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase 
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductDetailDto>> GetProductByIdAsync(GetProductDetailQuery query)
    {
        var categoryDetails = await _mediator.Send(query);
        return Ok(categoryDetails);
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateProductCommands command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtRoute(
            "GetProductById",
            new { id = response },
            command
        );
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductDto>>> GetAllAsync([FromQuery] GetProductQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Put(UpdateProductCommand updateProduct)
    {
        return Ok(await _mediator.Send(updateProduct));
    }
}