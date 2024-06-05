<<<<<<< HEAD
﻿using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Models;

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

    public async Task ClearCartAsync(int userId)
    {
        var cart = await _cartRepository.GetCartAsync(userId);
        if (cart == null)
        {
            throw new Exception("Cart not found.");
        }

        cart.CartItems.Clear();
        await _cartRepository.SaveChangesAsync();
=======
﻿using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class CartServices : ICartServices
    {
        public Task<Cart> AddCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> DeleteCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByIdAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateCartAsync(Cart cart)
        {
            throw new NotImplementedException();
        }
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    }
}
