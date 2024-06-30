using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Models.DTOs.OrderDTOs;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IOrderServices
    {
        Task<OrderDTO> PlaceOrderFromCartAsync(int userId, decimal paymentAmount);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(int userId);
        Task<OrderDTO> GetOrderByIdAsync(int orderId);
    }
}
