using VideoStoreManagmentAPI.Models.DTOs.AuthDTOs;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(UserRegisterDTO registerDto);
        Task<LoginReturnDTO> Login(UserLoginDTO loginDto);
    }
}
