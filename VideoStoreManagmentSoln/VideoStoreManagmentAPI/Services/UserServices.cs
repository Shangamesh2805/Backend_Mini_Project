using System.Threading.Tasks;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs.UserDTOs;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user with the specified ID.</returns>

        public async Task<User> UpdateUserDetails(int userId, UserUpdateDTO userUpdateDto)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            
            user.Name = userUpdateDto.Name;
            user.Email = userUpdateDto.Email;
            user.Age = userUpdateDto.Age;
            

            
            return await _userRepository.UpdateUser(user);
        }

        /// <summary>
        /// Updates the details of a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="userUpdateDto">The user details to update.</param>
        /// <returns>The updated user.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the user is not found.</exception>


        public async Task<User> ChangeMembership(int userId, MemberShipChangeDTO membershipChangeDto)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.Role = membershipChangeDto.NewRole;
            user.Membership = membershipChangeDto.NewMembershipType;
            return await _userRepository.UpdateUser(user);
            
        }
        /// <summary>
        /// Changes the membership details of a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="membershipChangeDto">The new membership details.</param>
        /// <returns>The updated user with changed membership.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the user is not found.</exception>

    }
}
