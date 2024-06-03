using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            var cartItem = new CartItem { };

            // Act
            var result = await repository.AddAsync(cartItem);

            // Assert
            Assert.NotNull(result);
            
        }

        [Test]
        public async Task Delete_ShouldDeleteCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem {  };
            await context.CartItems.AddAsync(cartItem);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.Delete(cartItem.CartItemId);

            // Assert
            Assert.NotNull(result);
            
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCartItems()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem {  };
            await context.CartItems.AddAsync(cartItem);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(cartItem.CartItemId);

            // Assert
            Assert.NotNull(result);
            
        }

        [Test]
        public async Task SaveChangesAsync_ShouldSaveChanges()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);

            // Act
            await repository.SaveChangesAsync();

            // Assert
           
        }

        [Test]
        public async Task Update_ShouldUpdateCartItem()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartItemRepository(context);
            var cartItem = new CartItem {  };
            await context.CartItems.AddAsync(cartItem);
            await context.SaveChangesAsync();

            // Act
            cartItem.Quantity = 5;
            var result = await repository.Update(cartItem);

            // Assert
            Assert.NotNull(result);
            
        }
    }
}
