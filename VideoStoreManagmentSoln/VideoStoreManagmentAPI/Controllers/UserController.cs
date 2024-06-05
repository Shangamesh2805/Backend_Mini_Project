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
<<<<<<< HEAD
   
=======
    [Authorize]
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

<<<<<<< HEAD
        [Authorize]
        [HttpGet("{id}/User_Data")]
       
=======
        [HttpGet("{id}/User_Data")]
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

<<<<<<< HEAD
        [Authorize]

        [HttpPut("{id}/Update_User")]
        public async Task<IActionResult> UpdateUserDetails(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
             await _userServices.UpdateUserDetails(id, userUpdateDto);
            return Ok(userUpdateDto);
           
            
        }

        [Authorize]

=======
        [HttpPut("{id}/Update_User")]
        public async Task<IActionResult> UpdateUserDetails(int id, [FromBody] UserUpdateDTO userUpdateDto)
        {
            await _userServices.UpdateUserDetails(id, userUpdateDto);
            return NoContent();
        }

>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        [HttpPut("{id}/change-membership")]
        public async Task<IActionResult> ChangeMembership(int id, [FromBody] MemberShipChangeDTO membershipChangeDto)
        {
            await _userServices.ChangeMembership(id, membershipChangeDto);
<<<<<<< HEAD
            return Ok(membershipChangeDto);
=======
            return NoContent();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
        }
    }
}
