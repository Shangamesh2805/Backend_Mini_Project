using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{id}/User_Data")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPut("{id}/Update_User")]
        public async Task<IActionResult> UpdateUserDetails(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            await _userServices.UpdateUserDetails(id, userUpdateDto);
            return NoContent();
        }

        [HttpPut("{id}/change-membership")]
        public async Task<IActionResult> ChangeMembership(int id, [FromBody] MemberShipChangeDTO membershipChangeDto)
        {
            await _userServices.ChangeMembership(id, membershipChangeDto);
            return NoContent();
        }
    }
}
