using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories;

namespace VideoStoreManagmentAPI.Test.Repositories
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private VideoStoreManagementContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<VideoStoreManagementContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new VideoStoreManagementContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Test]
        public async Task Register_ShouldAddUser()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Email = "test@example.com" };
            var password = "password123";

            // Act
            var result = await repository.Register(user, password);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(user.Email, result.Email);
            Assert.NotNull(result.PasswordHash);
            Assert.NotNull(result.PasswordSalt);
            Assert.AreEqual(1, context.Users.Count());
        }

        [Test]
        public async Task Login_ShouldReturnUser_WhenCredentialsAreValid()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var password = "password123";
            var user = new User { Email = "test@example.com" };
            await repository.Register(user, password);

            // Act
            var result = await repository.Login(user.Email, password);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(user.Email, result.Email);
        }

        [Test]
        public async Task Login_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            // Act
            var result = await repository.Login("nonexistent@example.com", "password");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task Login_ShouldReturnNull_WhenPasswordIsIncorrect()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var password = "password123";
            var user = new User { Email = "test@example.com" };
            await repository.Register(user, password);

            // Act
            var result = await repository.Login(user.Email, "wrongpassword");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task UserExists_ShouldReturnTrue_WhenUserExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Email = "test@example.com" };
            await repository.Register(user, "password123");

            // Act
            var result = await repository.UserExists(user.Email);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserExists_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            // Act
            var result = await repository.UserExists("nonexistent@example.com");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Email = "test@example.com" };
            await repository.Register(user, "password123");

            // Act
            var result = await repository.GetUserById(user.UserId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(user.Email, result.Email);
        }

        [Test]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);

            // Act
            var result = await repository.GetUserById(999);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task UpdateUser_ShouldUpdateExistingUser()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Email = "test@example.com" };
            await repository.Register(user, "password123");
            user.Email = "updated@example.com";

            // Act
            var result = await repository.UpdateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("updated@example.com", result.Email);
            var updatedUser = await repository.GetUserById(user.UserId);
            Assert.AreEqual("updated@example.com", updatedUser.Email);
        }

        [Test]
        public void UpdateUser_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { UserId = 999, Email = "nonexistent@example.com" };

            // Act & Assert
            Assert.ThrowsAsync<UserNotFoundException>(() => repository.UpdateUser(user));
        }
    }
}
