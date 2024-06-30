using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories;

namespace VideoStoreManagmentAPI.Test.Repositories
{
    [TestFixture]
    public class FeedBackRepositoryTests
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
        public async Task AddFeedback_ShouldAddFeedback()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);
            var feedback = new FeedBack
            {
                Rating = 4.5m,
                Comments = "Great video!",
                UserId = 1,
                VideoId = 1
            };

            // Act
            await repository.AddFeedback(feedback);
            var result = await context.FeedBacks.FirstOrDefaultAsync(f => f.FeedbackId == feedback.FeedbackId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(feedback.Rating, result.Rating);
        }

        [Test]
        public async Task DeleteFeedback_ShouldDeleteFeedback()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);
            var feedback = new FeedBack
            {
                Rating = 4.5m,
                Comments = "Great video!",
                UserId = 1,
                VideoId = 1
            };
            context.FeedBacks.Add(feedback);
            await context.SaveChangesAsync();

            // Act
            await repository.DeleteFeedback(feedback.FeedbackId);
            var result = await context.FeedBacks.FindAsync(feedback.FeedbackId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void DeleteFeedback_ShouldThrowException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.DeleteFeedback(999));
        }

        [Test]
        public async Task GetAllFeedbacks_ShouldReturnAllFeedbacks()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);
            context.FeedBacks.AddRange(
                new FeedBack { Rating = 4.5m, Comments = "Great video!", UserId = 1, VideoId = 1 },
                new FeedBack { Rating = 3.0m, Comments = "Average video", UserId = 2, VideoId = 2 }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllFeedbacks();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task UpdateFeedback_ShouldUpdateFeedback()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);
            var feedback = new FeedBack
            {
                Rating = 4.5m,
                Comments = "Great video!",
                UserId = 1,
                VideoId = 1
            };
            context.FeedBacks.Add(feedback);
            await context.SaveChangesAsync();

            var updatedFeedback = new FeedBack
            {
                FeedbackId = feedback.FeedbackId,
                Rating = 5.0m,
                Comments = "Awesome video!",
                UserId = 1,
                VideoId = 1
            };

            // Act
            await repository.UpdateFeedback(updatedFeedback);
            var result = await context.FeedBacks.FindAsync(feedback.FeedbackId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(updatedFeedback.Rating, result.Rating);
        }

        [Test]
        public void UpdateFeedback_ShouldThrowException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new FeedBackRepository(context);
            var feedback = new FeedBack
            {
                FeedbackId = 999,
                Rating = 4.5m,
                Comments = "Great video!",
                UserId = 1,
                VideoId = 1
            };

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await repository.UpdateFeedback(feedback));
        }
    }
}
