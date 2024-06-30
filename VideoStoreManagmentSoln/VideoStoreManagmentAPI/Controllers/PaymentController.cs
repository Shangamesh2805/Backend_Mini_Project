using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] MakePaymentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paymentDTO = new PaymentDTO
                {
                    OrderId = model.OrderId,
                    PaymentAmount = model.PaymentAmount,
                    Status = model.PaymentAmount == model.TotalAmount ? "Completed" : "Failed",
                    PaymentDate = DateTime.UtcNow
                };

                var payment = await _paymentService.MakePaymentAsync(model.OrderId, model.PaymentAmount);

                if (payment.Status == "Completed")
                {
                    return Ok(payment);
                }
                else
                {
                    return BadRequest("Payment failed.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CancelPayment")]
        public async Task<IActionResult> CancelPayment(int paymentId)
        {
            try
            {
                await _paymentService.CancelPaymentAsync(paymentId);
                return Ok("Payment cancelled successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPaymentByOrderId/{orderId}")]
        public async Task<IActionResult> GetPaymentByOrderId(int orderId)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
