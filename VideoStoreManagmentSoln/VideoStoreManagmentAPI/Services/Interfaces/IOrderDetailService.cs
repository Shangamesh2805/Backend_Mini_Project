using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.OrderDTOs;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}
