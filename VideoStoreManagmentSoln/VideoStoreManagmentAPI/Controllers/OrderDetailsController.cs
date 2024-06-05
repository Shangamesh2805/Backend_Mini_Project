using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailsService;

        public OrderDetailsController(IOrderDetailService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int orderId)
        {
            try
            {
                var orderDetails = await _orderDetailsService.GetOrderDetailsByOrderIdAsync(orderId);
                if (orderDetails == null || !orderDetails.Any())
                {
                    return NotFound();
                }
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
