using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExists(string email);
        Task<User> GetUserById(int id);
<<<<<<< HEAD
        Task<User> UpdateUser(User user);
=======
        Task UpdateUser(User user);
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74

    }
}
