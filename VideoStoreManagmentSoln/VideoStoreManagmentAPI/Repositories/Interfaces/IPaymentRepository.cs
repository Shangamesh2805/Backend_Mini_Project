using System.Threading.Tasks;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);
        Task UpdatePaymentStatusAsync(int paymentId, string status);
    }
}
