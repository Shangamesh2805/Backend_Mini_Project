using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId);
    }
}
