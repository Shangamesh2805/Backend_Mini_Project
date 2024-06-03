using VideoStoreManagmentAPI.Models;
<<<<<<< HEAD
using VideoStoreManagmentAPI.Models.DTOs;
=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7

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

<<<<<<< HEAD
        Task<User> GetUserById(int id);
        Task UpdateUserDetails(int userId, UserUpdateDTO userUpdateDto);
        Task ChangeMembership(int userId, MemberShipChangeDTO membershipChangeDto);

=======
        Task<IEnumerable<Videos>> GetAvailableVideosAsync();
        Task<Orders> PlaceOrderAsync(int userId, int cartId);
        Task<IEnumerable<Orders>> GetUserOrdersAsync(int userId);
        Task<Cart> GetUserCartAsync(int userId);
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    }
}
