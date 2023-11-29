using Microsoft.AspNetCore.Mvc;

using Inveon.eCommerceExample.Carts.API.Infrastructure;
using Inveon.eCommerceExample.Carts.API.Models;
using Inveon.eCommerceExample.Carts.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Inveon.eCommerceExample.Carts.API.Controllers;

[ApiController]
[Route("api/v1/carts")]
public class CartController : ControllerBase
{
    private readonly CartContext _cartCtx;
    private readonly IProductService _productService;

    public CartController(CartContext cartCtx, IProductService productService)
    {
        _cartCtx = cartCtx;
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult<CartResponse>> CreateCart([FromBody] CreateCartRequest createCart)
    {
        // TODO: In the future this check can be removed so that customers can
        // have multiple carts for behaviour analysis
        // if (await _cartCtx.Carts.SingleOrDefaultAsync(c => c.CustomerId == createCart.CustomerId) != null)
        // {
        //     return BadRequest();
        // }

        var cart = new Cart(createCart.CustomerId);
        var cartItem = new CartItem(cart.Id, createCart.ProductId);

        cart.Items.Add(cartItem);
        await _cartCtx.Carts.AddAsync(cart);
        await _cartCtx.SaveChangesAsync();

        var cartRes = new CartResponse
        {
            Id = cart.Id,
        };

        var product = await _productService.GetProduct(cartItem.ProductId);
        if (product == null)
        {
            return NotFound();
        }
        cartRes.Items.Add(product);

        return Ok(cartRes);
    }

    [HttpGet]
    [Route("{cartId:guid}")]
    public async Task<ActionResult<CartResponse>> GetCart(Guid cartId)
    {
        var cart = await _cartCtx.Carts.SingleOrDefaultAsync(c => c.Id == cartId);
        if (cart == null)
        {
            return BadRequest();
        }
        await _cartCtx.Entry(cart).Collection(c => c.Items).LoadAsync();
        var products = new List<Product>();
        Console.WriteLine("Hello");
        foreach (var item in cart.Items)
        {
            Console.WriteLine(item);
            var product = await _productService.GetProduct(item.ProductId);
            if (product == null)
            {
                // TODO: Handle if product gets deleted or stock count goes to zero.
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            product.Quantity = item.Quantity;
            products.Add(product);
        }

        return Ok(new CartResponse { Id = cart.Id, Items = products });

    }

    [HttpPost]
    [Route("{cartId:guid}/items")]
    public async Task<ActionResult> AddItemToCart(Guid cartId, [FromBody] AddItemRequest addItemRequest)
    {
        var cart = await _cartCtx.Carts.SingleOrDefaultAsync(c => c.Id == cartId);
        if (cart is null)
        {
            return NotFound();
        }
        var item = new CartItem(cartId, addItemRequest.ProductId);
        await _cartCtx.CartItems.AddAsync(item);
        await _cartCtx.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch]
    [Route("{cartId:guid}/items/{productId:guid}")]
    public async Task<ActionResult> UpdateCartItemQuantity(Guid cartId, Guid productId, [FromBody] UpdateQuantityRequest updateQuantityRequest)
    {
        if (updateQuantityRequest.Quantity < 1)
        {
            return BadRequest();
        }

        var cartItem = await _cartCtx
            .CartItems
            .SingleOrDefaultAsync(i => i.CartId == cartId && i.ProductId == productId);
        if (cartItem == null)
        {
            return BadRequest();
        }

        cartItem.Quantity = updateQuantityRequest.Quantity;

        _cartCtx.CartItems.Update(cartItem);
        await _cartCtx.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{cartId:guid}/items/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteCartItem(Guid cartId, Guid productId)
    {
        var cartItem = await _cartCtx
            .CartItems
            .SingleOrDefaultAsync(i => i.CartId == cartId && i.ProductId == productId);
        if (cartItem == null)
        {
            return NotFound();
        }

        _cartCtx.CartItems.Remove(cartItem);
        await _cartCtx.SaveChangesAsync();

        return NoContent();
    }
}
