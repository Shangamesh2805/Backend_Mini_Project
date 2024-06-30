using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CartItem cartItem)
        {
            try
            {
                var addedCartItem = await _cartItemService.AddCartItemAsync(cartItem);
                return CreatedAtAction(nameof(GetCartItemsByCartId), new { cartId = cartItem.CartId }, addedCartItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveItem/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            try
            {
                var removedCartItem = await _cartItemService.RemoveCartItemAsync(cartItemId);
                return Ok(removedCartItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCartItem/{cartId}")]
        public async Task<IActionResult> GetCartItemsByCartId(int cartId)
        {
            try
            {
                var cartItems = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
                if (cartItems == null || !cartItems.Any())
                {
                    throw new  CartItemNotFoundException();
                }
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
