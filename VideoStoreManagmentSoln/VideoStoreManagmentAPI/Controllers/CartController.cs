using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<CartDTO>> GetCart()
    {
        var userId = GetUserId();
        var cartDto = await _cartService.GetCartAsync(userId);

        if (cartDto == null)
        {
            return NotFound("Cart not found.");
        }

        return Ok(cartDto);
    }

    [HttpPost("items")]
    public async Task<ActionResult> AddCartItem(AddCartItemDTO addCartItemDto)
    {
        var userId = GetUserId();
        await _cartService.AddCartItemAsync(userId, addCartItemDto);
        return Ok();
    }

    [HttpDelete("items/{itemId}")]
    public async Task<ActionResult> RemoveCartItem(int itemId)
    {
        var userId = GetUserId();
        await _cartService.RemoveCartItemAsync(userId, itemId);
        return Ok();
    }

    [HttpDelete("items")]
    public async Task<ActionResult> ClearCart()
    {
        var userId = GetUserId();
        await _cartService.ClearCartAsync(userId);
        return Ok();
    }

    private int GetUserId()
    {
        var nameIdentifierClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (nameIdentifierClaim == null)
        {
            throw new InvalidOperationException("User identifier claim is missing.");
        }

        return int.Parse(nameIdentifierClaim.Value);
    }

}
