using VideoStoreManagmentAPI.Models.DTOs;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(UserRegisterDTO registerDto);
        Task<string> Login(UserLoginDTO loginDto);
    }
}
