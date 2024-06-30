using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.DTOs;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderService;
        private readonly IOrderDetailService _orderDetailsService;

        public OrdersController(IOrderServices orderService, IOrderDetailService orderDetailsService)
        {
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrderFromCart([FromBody] PlaceOrderDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _orderService.PlaceOrderFromCartAsync(model.UserId, model.PaymentAmount);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrder/{userId}")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserIdAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderDetails/{orderId}")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                var orderDetails = await _orderDetailsService.GetOrderDetailsByOrderIdAsync(orderId);
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
