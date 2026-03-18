namespace BaseCleanArchitecture.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using BaseCleanArchitecture.Application.Features.Common.Commands;
using BaseCleanArchitecture.Application.Features.Common.Queries;
using BaseCleanArchitecture.Application.Features.Products;
using BaseCleanArchitecture.Domain.Entities;


public class ProductController : BaseApiController
{
    public ProductController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllQuery<Product, ProductDto>(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetByIdQuery<Product, ProductDto>(id), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new CreateCommand<Product, ProductDto>(dto), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductDto dto, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new UpdateCommand<Product, ProductDto>(id, dto), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new DeleteCommand<Product>(id), cancellationToken);
        return result ? NoContent() : NotFound();
    }
}
