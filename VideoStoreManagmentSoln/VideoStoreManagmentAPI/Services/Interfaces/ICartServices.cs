<<<<<<< HEAD
﻿using VideoStoreManagmentAPI.Models.DTOs;

public interface ICartService
{
    Task<CartDTO> GetCartAsync(int userId);
    Task AddCartItemAsync(int userId, AddCartItemDTO addCartItemDto);
    Task RemoveCartItemAsync(int userId, int itemId);
    Task ClearCartAsync(int userId);
=======
﻿using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface ICartServices
    {
        Task<Cart> AddCartAsync(Cart cart);
        Task<Cart> DeleteCartAsync(int cartId);
        Task<IEnumerable<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int cartId);
        Task<Cart> UpdateCartAsync(Cart cart);
    }
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
}
