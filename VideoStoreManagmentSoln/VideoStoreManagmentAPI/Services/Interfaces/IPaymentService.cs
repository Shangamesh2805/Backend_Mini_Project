using System.Threading.Tasks;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDTO> MakePaymentAsync(int orderId, decimal paymentAmount);
        Task<PaymentDTO> GetPaymentByOrderIdAsync(int orderId);
        Task CancelPaymentAsync(int paymentId);
    }
}
