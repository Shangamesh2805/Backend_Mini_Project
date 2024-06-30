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
    public class OrderDetailRepositoryTests
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
        public async Task Add_ShouldAddOrderDetail()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetails
            {
                OrderId = 1,
                VideoId = 1
            };

            // Act
            var result = await repository.AddAsync(orderDetail);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(orderDetail.OrderId, result.OrderId);
        }

        [Test]
        public async Task Delete_ShouldDeleteOrderDetail()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetails
            {
                OrderId = 1,
                VideoId = 1
            };
            context.OrderDetails.Add(orderDetail);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.Delete(orderDetail.OrderDetailId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(orderDetail.OrderDetailId, result.OrderDetailId);
        }

        [Test]
        public void Delete_ShouldThrowException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<NoOrderDetailFoundException>(async () => await repository.Delete(999));
        }

        [Test]
        public async Task GetById_ShouldReturnOrderDetail()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetails
            {
                OrderId = 1,
                VideoId = 1
            };
            context.OrderDetails.Add(orderDetail);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(orderDetail.OrderDetailId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(orderDetail.OrderDetailId, result.OrderDetailId);
        }

        [Test]
        public void GetById_ShouldThrowException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.GetByIdAsync(999));
        }

        [Test]
        public async Task Update_ShouldUpdateOrderDetail()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetails
            {
                OrderId = 1,
                VideoId = 1
            };
            context.OrderDetails.Add(orderDetail);
            await context.SaveChangesAsync();

            var updatedOrderDetail = new OrderDetails
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderId = 2,
                VideoId = 2
            };

            // Act
            var result = await repository.Update(updatedOrderDetail);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(updatedOrderDetail.OrderId, result.OrderId);
        }

        [Test]
        public void Update_ShouldThrowException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetails
            {
                OrderDetailId = 999,
                OrderId = 1,
                VideoId = 1
            };

            // Act & Assert
            Assert.ThrowsAsync<NoOrderDetailFoundException>(async () => await repository.Update(orderDetail));
        }

        [Test]
        public async Task GetAll_ShouldReturnAllOrderDetails()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new OrderDetailRepository(context);
            context.OrderDetails.AddRange(
                new OrderDetails { OrderId = 1, VideoId = 1 },
                new OrderDetails { OrderId = 2, VideoId = 2 }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());
        }
    }
}
