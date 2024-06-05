using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using VideoStoreManagmentAPI.Exceptions;

namespace VideoStoreManagmentAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoStoreManagementContext _context;

        public UserRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = ComputeHash(password, user.PasswordSalt);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
                if (user == null || !VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't login ", ex);
            }
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
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

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch
            {
                throw new UserNotFoundException();
            }

        }

        
    }
}
