using FoodStock.Application.Functions.ProductFunctions.Commands.CreateProduct;
using FoodStock.Application.Functions.ProductFunctions.Commands.DeleteProduct;
using FoodStock.Application.Functions.ProductFunctions.Commands.UpdateProduct;
using FoodStock.Application.Functions.ProductFunctions.Queries.GetProductDetail;
using FoodStock.Application.Functions.ProductFunctions.Queries.GetProductsList;
using FoodStock.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodStock.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductListViewModel>>> GetAll()
    {
        var products = await _mediator.Send(new GetProductListQuery());
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDetailViewModel>> GetProduct([FromRoute] Guid id)
    {
        var product = await _mediator.Send(new GetProductDetailQuery { Id = id });
        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateProductCommandResponse>> Post([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        
        if (!product.Success && product.ValidationErrors != null)
        {
            return BadRequest(product);
        }
        return Ok(product);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateProductCommandResponse>> Update([FromBody] UpdateProductCommand command,
        [FromRoute] Guid id)
    {
        var product = await _mediator.Send(command with { Id = id });
        if (!product.Success && product.ValidationErrors != null)
        {
            return BadRequest(product);
        }
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
         await _mediator.Send(new DeleteProductCommand() with { Id = id });
        return NoContent();
    }
}
