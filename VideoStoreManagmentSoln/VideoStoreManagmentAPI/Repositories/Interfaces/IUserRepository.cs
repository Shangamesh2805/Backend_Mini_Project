using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExists(string email);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);

    }
}
