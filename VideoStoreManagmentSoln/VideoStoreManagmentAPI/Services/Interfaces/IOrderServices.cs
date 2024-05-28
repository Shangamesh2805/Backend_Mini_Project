using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<Orders> PlaceOrderFromCartAsync(int userId);
        Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(int userId);
    }
}
