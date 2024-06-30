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
    public class CartItemRepositoryTests
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
        public async Task AddAsync_ShouldAddCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { CartId = 1, VideoId = 1, Quantity = 2 };

            // Act
            var result = await repository.AddAsync(cartItem);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.CartId, Is.EqualTo(cartItem.CartId));
            Assert.That(result.VideoId, Is.EqualTo(cartItem.VideoId));
            Assert.That(result.Quantity, Is.EqualTo(cartItem.Quantity));
        }

        [Test]
        public async Task Update_ShouldUpdateCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { CartId = 1, VideoId = 1, Quantity = 2 };
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();

            // Act
            cartItem.Quantity = 3;
            var result = await repository.Update(cartItem);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Quantity, Is.EqualTo(3));
        }

        [Test]
        public async Task Delete_ShouldDeleteCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { CartId = 1, VideoId = 1, Quantity = 2 };
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.Delete(cartItem.CartItemId);

            // Assert
            Assert.NotNull(result);
            Assert.ThrowsAsync<NoCartItemWithGivenIDException>(async () => await repository.GetByIdAsync(cartItem.CartItemId));
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem { CartId = 1, VideoId = 1, Quantity = 2 };
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(cartItem.CartItemId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.CartId, Is.EqualTo(cartItem.CartId));
            Assert.That(result.VideoId, Is.EqualTo(cartItem.VideoId));
            Assert.That(result.Quantity, Is.EqualTo(cartItem.Quantity));
        }

        [Test]
        public async Task GetByIdAsync_ShouldThrowNoCartItemWithGivenIDException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<NoCartItemWithGivenIDException>(async () => await repository.GetByIdAsync(999));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCartItems()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            context.CartItems.AddRange(
                new CartItem { CartId = 1, VideoId = 1, Quantity = 2 },
                new CartItem { CartId = 1, VideoId = 2, Quantity = 3 });
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
