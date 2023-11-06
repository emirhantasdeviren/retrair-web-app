using Inveon.eCommerceExample.Products.API.Models;
using Inveon.eCommerceExample.Products.API.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inveon.eCommerceExample.Products.API.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductContext _productCtx;

    public ProductsController(ProductContext productCtx)
    {
        _productCtx = productCtx;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> ProductsAsync()
    {
        var products = await _productCtx.Products.ToListAsync();

        return products;
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> ProductByIdAsync(Guid id)
    {
        var product = await _productCtx.Products.SingleOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateProductAsync([FromBody] Product product)
    {
        _productCtx.Products.Add(product);

        await _productCtx.SaveChangesAsync();

        // return CreatedAtAction(nameof(ProductByIdAsync), new { id = product.Id }, product);
        return StatusCode(StatusCodes.Status201Created);
    }
}
