using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> Register(UserRegisterDTO registerDto)
        {
            if (await _userRepository.UserExists(registerDto.Email))
                throw new Exception("User already exists");

            var user = new User
            {
                Name = registerDto.Name,
                Age = registerDto.Age,
                Email = registerDto.Email,
                PasswordSalt = GenerateSalt(),
                PasswordHash = ComputeHash(registerDto.Password, GenerateSalt()),
                Membership = registerDto.Membership,
                Role = registerDto.Role,
                DeviceLimit = registerDto.Membership == UserType.GoldenMember ? 2 : 1,
                DiscountFactor = registerDto.Membership == UserType.GoldenMember ? 0.2m : 0m,
                Status = "Active"
            };

            await _userRepository.Register(user, registerDto.Password);

            return _tokenService.GenerateToken(user);
        }

        public async Task<string> Login(UserLoginDTO loginDto)
        {
            var user = await _userRepository.Login(loginDto.Email, loginDto.Password);
            if (user == null)
                throw new Exception("Invalid credentials");

            return _tokenService.GenerateToken(user);
        }

        private byte[] GenerateSalt()
        {
            using var hmac = new HMACSHA512();
            return hmac.Key;
        }

        private byte[] ComputeHash(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
