<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories;

namespace VideoStoreManagmentAPI.Test.Repositories
{
    [TestFixture]
    public class CartRepositoryTests
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
        public async Task GetCartAsync_ShouldReturnCart_WhenCartExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);
            var cart = new Cart { UserId = 1, CartItems = new List<CartItem>() };
            context.Carts.Add(cart);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetCartAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.UserId);
        }

        [Test]
        public void GetCartAsync_ShouldThrowCartException_WhenExceptionOccurs()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<CartException>(async () => await repository.GetCartAsync(-1));
        }

        [Test]
        public async Task CreateCartAsync_ShouldCreateAndReturnCart()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);

            // Act
            var result = await repository.CreateCartAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual(1, await context.Carts.CountAsync());
        }

        [Test]
        public void CreateCartAsync_ShouldThrowException_WhenExceptionOccurs()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.CreateCartAsync(-1));
        }

        [Test]
        public async Task GetCartItemAsync_ShouldReturnCartItem_WhenItemExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);
            var cart = new Cart { UserId = 1 };
            var cartItem = new CartItem { CartId = cart.CartId, VideoId = 1 };
            context.Carts.Add(cart);
            context.CartItems.Add(cartItem);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetCartItemAsync(cart.CartId, cartItem.CartItemId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(cart.CartId, result.CartId);
            Assert.AreEqual(cartItem.CartItemId, result.CartItemId);
        }

        [Test]
        public async Task GetVideoAsync_ShouldReturnVideo_WhenVideoExists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);
            var video = new Videos { Title = "Test Video", Genre = Genre.Action, Availability = true };
            context.Videos.Add(video);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetVideoAsync(video.VideoId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(video.VideoId, result.VideoId);
        }

        [Test]
        public void GetVideoAsync_ShouldThrowException_WhenExceptionOccurs()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.GetVideoAsync(-1));
        }

        [Test]
        public async Task SaveChangesAsync_ShouldSaveChanges()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new CartRepository(context);
            var cart = new Cart { UserId = 1, CartItems = new List<CartItem>() };
            context.Carts.Add(cart);

            // Act
            await repository.SaveChangesAsync();
            var result = await context.Carts.FirstOrDefaultAsync(c => c.UserId == 1);

            // Assert
            Assert.NotNull(result);
        }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.RepositoryTests
{
    internal class CartRepositoryTests
    {
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
    }
}
