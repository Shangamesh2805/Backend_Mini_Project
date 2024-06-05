<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
﻿using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoStoreManagmentAPI.Models;
<<<<<<< HEAD
=======
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderService;

        public OrdersController(IOrderServices orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrderFromCart(int userId)
        {
            try
            {
                var order = await _orderService.PlaceOrderFromCartAsync(userId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        [Authorize]
<<<<<<< HEAD
        [ProducesResponseType(typeof(IList<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
=======
<<<<<<< HEAD
        [ProducesResponseType(typeof(IList<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
=======
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
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
    }
}
