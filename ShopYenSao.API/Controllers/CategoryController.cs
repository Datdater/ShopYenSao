using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopYenSao.Application.Features.Category.Commands.CreateCategory;
using ShopYenSao.Application.Features.Category.Commands.DeleteCategory;
using ShopYenSao.Application.Features.Category.Commands.GetAllCategory;
using ShopYenSao.Application.Features.Category.Commands.UpdateCategory;
using ShopYenSao.Application.Features.Category.Queries.GetAllCategory;
using ShopYenSao.Application.Features.Category.Queries.GetCategoryDetails;

namespace ShopYenSao.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _mediator.Send(new GetCategoryQuery());
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<ActionResult<CategoryDetailDto>> GetCategoryAsync(Guid id)
    {
        var categoryDetails = await _mediator.Send(new GetCategoryDetailsQuery(id));
        return Ok(categoryDetails);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateCategoryCommand createCategory)
    {
        var response = await _mediator.Send(createCategory);
        return CreatedAtRoute(
            "GetCategoryById",
            new { id = response },
            createCategory
        );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateCategoryCommand updateCategory)
    {
        await _mediator.Send(updateCategory);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        DeleteCategoryCommand categoryCommand = new DeleteCategoryCommand() { Id = id }; 
        await _mediator.Send(categoryCommand);
        return NoContent();
    }
}