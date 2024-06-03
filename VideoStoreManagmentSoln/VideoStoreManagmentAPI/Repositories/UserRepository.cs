using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Contexts;
<<<<<<< HEAD
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace VideoStoreManagmentAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VideoStoreManagementContext _context;
=======
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;

namespace VideoStoreManagmentAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        protected readonly VideoStoreManagementContext _context;
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7

        public UserRepository(VideoStoreManagementContext context)
        {
            _context = context;
        }
<<<<<<< HEAD

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
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
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

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
=======
        public async Task<User> AddAsync(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _context.Users.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            throw new OrderNotFoundException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                return item;
            }
            throw new OrderNotFoundException();
        }
    

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<User> Update(User item)
        {
        var existinguser = await GetByIdAsync(item.UserId);
        if (existinguser != null)
        {
            _context.Entry(existinguser).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existinguser;
        }
        throw new OrderNotFoundException();
    }
}
}
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
