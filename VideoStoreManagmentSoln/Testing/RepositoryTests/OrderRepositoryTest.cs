using Microsoft.EntityFrameworkCore;
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
    public class OrderRepositoryTests
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
        public async Task AddOrder_ShouldAddOrder()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);
            var order = new Orders
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                RentalExpireDate = DateTime.Now.AddDays(7),
                TotalAmount = 29.99m
            };

            // Act
            var result = await repository.AddAsync(order);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(order.TotalAmount, result.TotalAmount);
        }

        [Test]
        public async Task DeleteOrder_ShouldDeleteOrder()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);
            var order = new Orders
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                RentalExpireDate = DateTime.Now.AddDays(7),
                TotalAmount = 29.99m
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.Delete(order.OrderId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(order.OrderId, result.OrderId);
        }

        [Test]
        public void DeleteOrder_ShouldThrowNoOrderNotFoundException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<NoOrderFounDException>(async () => await repository.Delete(999));
        }

        [Test]  
        public async Task GetOrderById_ShouldReturnOrder()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);
            var order = new Orders
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                RentalExpireDate = DateTime.Now.AddDays(7),
                TotalAmount = 29.99m
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(order.OrderId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(order.OrderId, result.OrderId);
        }

        [Test]
        public void GetOrderById_ShouldThrowNoOrderNotFoundException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<UserNotFoundException>(async () => await repository.GetByIdAsync(999));
        }

        [Test]
        public async Task UpdateOrder_ShouldUpdateOrder()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);
            var order = new Orders
            {
                UserId = 1,
                OrderDate = DateTime.Now,
                RentalExpireDate = DateTime.Now.AddDays(7),
                TotalAmount = 29.99m
            };
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            var updatedOrder = new Orders
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                RentalExpireDate = order.RentalExpireDate,
                TotalAmount = 39.99m
            };

            // Act
            var result = await repository.Update(updatedOrder);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(updatedOrder.TotalAmount, result.TotalAmount);
        }

        [Test]
        public void UpdateOrder_ShouldThrowNoOrderNotFoundException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderRepository(context);
            var order = new Orders
            {
                OrderId = 999,
                UserId = 1,
                OrderDate = DateTime.Now,
                RentalExpireDate = DateTime.Now.AddDays(7),
                TotalAmount = 29.99m
            };

            // Act & Assert
            Assert.ThrowsAsync<NoOrderFounDException>(async () => await repository.Update(order));
        }
       
    }
}
