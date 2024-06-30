using System;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly Lazy<IOrderServices> _orderService;

        public PaymentService(IPaymentRepository paymentRepository, Lazy<IOrderServices> orderService)
        {
            _paymentRepository = paymentRepository;
            _orderService = orderService;
        }

        public async Task<PaymentDTO> MakePaymentAsync(int orderId, decimal paymentAmount)
        {
            var order = await _orderService.Value.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            if (paymentAmount == order.TotalAmount)
            {
                order.Status = "Completed";
            }
            else
            {
                order.Status = "Failed";
            }

            var payment = new Payment
            {
                OrderId = orderId,
                Amount = paymentAmount,
                Status = order.Status,
                PaymentDate = DateTime.UtcNow
            };

            var addedPayment = await _paymentRepository.AddPaymentAsync(payment);

            return new PaymentDTO
            {
                PaymentId = addedPayment.PaymentId,
                OrderId = addedPayment.OrderId,
                PaymentAmount = addedPayment.Amount,
                Status = addedPayment.Status
            };
        }

        public async Task<PaymentDTO> GetPaymentByOrderIdAsync(int orderId)
        {
            var payment = await _paymentRepository.GetPaymentByOrderIdAsync(orderId);
            if (payment == null)
            {
                return null;
            }

            return new PaymentDTO
            {
                PaymentId = payment.PaymentId,
                OrderId = payment.OrderId,
                PaymentAmount = payment.Amount,
                Status = payment.Status
            };
        }

        public async Task CancelPaymentAsync(int paymentId)
        {
            await _paymentRepository.UpdatePaymentStatusAsync(paymentId, "Cancelled");
        }
    }
}
