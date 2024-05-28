using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
