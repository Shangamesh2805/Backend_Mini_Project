using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Exceptions;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Models.DTOs;
using VideoStoreManagmentAPI.Repositories;

namespace VideoStoreManagmentAPI.Test.Repositories
{
    [TestFixture]
    public class VideoRepositoryTests
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
        public async Task GetAllVideos_ShouldReturnAllVideos()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            context.Videos.AddRange(
                new Videos { Title = "Video 1", Genre = Genre.Action, Availability = true },
                new Videos { Title = "Video 2", Genre = Genre.Comedy, Availability = false }
            );
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllVideos();

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetVideoById_ShouldReturnVideo()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var video = new Videos { Title = "Video 1", Genre = Genre.Action, Availability = true };
            context.Videos.Add(video);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetVideoById(video.VideoId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo(video.Title));
        }

        [Test]
        public void GetVideoById_ShouldThrowNoVideoWithGivenVideoIDException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<NoVideoWithGivenVideoIDException>(async () => await repository.GetVideoById(999));
        }

        [Test]
        public async Task AddVideo_ShouldAddVideo()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var videoDto = new VideoDTO
            {
                Title = "New Video",
                Description = "Description",
                Genre = Genre.Action,
                Availability = true,
                VideoFormat = VideoFormat.DVD,
                Price = 9.99m,
                VideoCount = 10,
                PublisherId = 1
            };

            // Add a publisher
            var publisher = new User { UserId = 1, Name = "Test Publisher" };
            context.Users.Add(publisher);
            await context.SaveChangesAsync();

            // Act
            await repository.AddVideo(videoDto, 1);
            var result = await context.Videos.FirstOrDefaultAsync(v => v.Title == videoDto.Title);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo(videoDto.Title));
        }

        [Test]
        public void AddVideo_ShouldThrowNoPublisherWithGivenIDException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var videoDto = new VideoDTO
            {
                Title = "New Video",
                Description = "Description",
                Genre = Genre.Action,
                Availability = true,
                VideoFormat = VideoFormat.DVD,
                Price = 9.99m,
                VideoCount = 10,
                PublisherId = 1
            };

            // Act & Assert
            Assert.ThrowsAsync<NoPublisherWithGivenIDException>(async () => await repository.AddVideo(videoDto, 999));
        }

        [Test]
        public async Task UpdateVideo_ShouldUpdateVideo()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var video = new Videos { Title = "Original Title", Description = "Original Description", Genre = Genre.Action, Availability = true };
            context.Videos.Add(video);
            await context.SaveChangesAsync();
            var videoDto = new VideoDTO
            {
                VideoId = video.VideoId,
                Title = "Updated Title",
                Description = "Updated Description",
                Genre = Genre.Comedy,
                Availability = false,
                VideoFormat = VideoFormat.BlueRay,
                Price = 14.99m,
                VideoCount = 5,
                PublisherId = 1
            };

            // Act
            await repository.UpdateVideo(videoDto);
            var result = await context.Videos.FindAsync(video.VideoId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Title, Is.EqualTo("Updated Title"));
            Assert.That(result.Description, Is.EqualTo("Updated Description"));
            Assert.That(result.Genre, Is.EqualTo(Genre.Comedy));
        }

        [Test]
        public void UpdateVideo_ShouldThrowNoVideoWithGivenVideoIDException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var videoDto = new VideoDTO
            {
                VideoId = 999,
                Title = "Non-existent Title",
                Description = "Non-existent Description",
                Genre = Genre.Action,
                Availability = true,
                VideoFormat = VideoFormat.DVD,
                Price = 9.99m,
                VideoCount = 10,
                PublisherId = 1
            };

            // Act & Assert
            Assert.ThrowsAsync<NoVideoWithGivenVideoIDException>(async () => await repository.UpdateVideo(videoDto));
        }

        [Test]
        public async Task DeleteVideo_ShouldDeleteVideo()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);
            var video = new Videos { Title = "Video to be deleted", Genre = Genre.Action, Availability = true };
            context.Videos.Add(video);
            await context.SaveChangesAsync();

            // Act
            await repository.DeleteVideo(video.VideoId);
            var result = await context.Videos.FindAsync(video.VideoId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void DeleteVideo_ShouldThrowNoVideoWithGivenVideoIDException()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new VideoRepository(context);

            // Act & Assert
            Assert.ThrowsAsync<NoVideoWithGivenVideoIDException>(async () => await repository.DeleteVideo(999));
        }
    }
}
