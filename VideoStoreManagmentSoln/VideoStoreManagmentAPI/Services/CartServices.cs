using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.CartDTOs;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDTO> GetCartAsync(int userId)
    {
        var cart = await _cartRepository.GetCartAsync(userId);
        if (cart == null)
        {
            return null;
        }

        var cartDto = new CartDTO
        {
            CartId = cart.CartId,
            Items = cart.CartItems.Select(ci => new CartItemDTO
            {
                Id = ci.CartItemId,
                VideoId = ci.VideoId,
                VideoTitle = ci.Video.Title,
                Quantity = ci.Quantity
            }).ToList()
        };
        return cartDto;
    }

    /// <summary>
    /// Retrieves a cart for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>The cart details as a <see cref="CartDTO"/></returns>

    public async Task AddCartItemAsync(int userId, AddCartItemDTO addCartItemDto)
    {
        var cart = await _cartRepository.GetCartAsync(userId);
        if (cart == null)
        {
            cart = await _cartRepository.CreateCartAsync(userId);
        }

        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.VideoId == addCartItemDto.VideoId);
        if (existingItem != null)
        {
            existingItem.Quantity += addCartItemDto.Quantity;
        }
        else
        {
            var video = await _cartRepository.GetVideoAsync(addCartItemDto.VideoId);
            if (video == null)
            {
                throw new Exception("Video not found.");
            }

            var cartItem = new CartItem
            {
                VideoId = addCartItemDto.VideoId,
                Quantity = addCartItemDto.Quantity,
                Video = video
            };
            cart.CartItems.Add(cartItem);
        }

        await _cartRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Adds an item to the cart for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="addCartItemDto">The details of the item to add.</param>

    public async Task RemoveCartItemAsync(int userId, int itemId)
    {
        var cart = await _cartRepository.GetCartAsync(userId);
        if (cart == null)
        {
            throw new Exception("Cart not found.");
        }

        var cartItem = await _cartRepository.GetCartItemAsync(cart.CartId, itemId);
        if (cartItem == null)
        {
            throw new Exception("Item not found.");
        }

        cart.CartItems.Remove(cartItem);
        await _cartRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Removes an item from the cart for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="itemId">The ID of the item to remove.</param>

    public async Task ClearCartAsync(int userId)
    {
        var cart = await _cartRepository.GetCartAsync(userId);
        if (cart == null)
        {
            throw new Exception("Cart not found.");
        }

        cart.CartItems.Clear();
        await _cartRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Clears all items from the cart for a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
}
