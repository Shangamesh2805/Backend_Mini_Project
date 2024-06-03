using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;

namespace VideoStoreManagmentAPI.Interfaces
{
    public interface IUserServices
    {
        //Task<IEnumerable<Videos>> GetAllVideosAsync();
        //Task<Cart> GetCartByUserIdAsync(int userId);
        //Task<CartItem> AddToCartAsync(int userId, int videoId);
        //Task<CartItem> RemoveFromCartAsync(int userId, int cartItemId);
        //Task<Orders> PlaceOrderAsync(int userId);
        //Task<IEnumerable<Orders>> GetUserOrdersAsync(int userId);

        Task<User> GetUserById(int id);
        Task UpdateUserDetails(int userId, UserUpdateDTO userUpdateDto);
        Task ChangeMembership(int userId, MemberShipChangeDTO membershipChangeDto);

    }
}
