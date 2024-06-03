using System.Threading.Tasks;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
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

        public async Task UpdateUserDetails(int userId, UserUpdateDTO userUpdateDto)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            // Update user properties
            user.Name = userUpdateDto.Name;
            user.Email = userUpdateDto.Email;
            user.Age = userUpdateDto.Age;
            

            await _userRepository.UpdateUser(user);
        }

        public async Task ChangeMembership(int userId, MemberShipChangeDTO membershipChangeDto)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.Role = membershipChangeDto.NewRole;
            user.Membership = membershipChangeDto.NewMembershipType;
            await _userRepository.UpdateUser(user);
        }
    }
}
