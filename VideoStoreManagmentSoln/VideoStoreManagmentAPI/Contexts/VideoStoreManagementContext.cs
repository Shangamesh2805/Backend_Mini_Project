using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Contexts
{
    public class VideoStoreManagementContext : DbContext
    {
        public VideoStoreManagementContext(DbContextOptions<VideoStoreManagementContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Videos> Videos { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Tojo", Age = 25, Membership = UserType.NormalMember,
                    DeviceLimit = 1, DiscountFactor = 0 },
                new User { UserId = 2, Name = "Tanjiro", Age = 30, Membership = UserType.GoldenMember, 
                    DeviceLimit = 2, DiscountFactor = 2 }
            );
            modelBuilder.Entity<Videos>().HasData(
                new Videos { VideoId = 1, Title = "Inception", Genre = "Sci-Fi", VideoFormat = VideoFormat.DVD, Price = 9.99m, 
                    Availability = true, Description = "A mind-bending thriller", PublisherId = 1 },
                new Videos { VideoId = 2, Title = "The Matrix", Genre = "Action", VideoFormat = VideoFormat.BlueRay, Price = 14.99m, 
                    Availability = true, Description = "A hacker discovers reality", PublisherId = 2 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, PublisherName = "Warner Bros" },
                new Publisher { PublisherId = 2, PublisherName = "20th Century Fox" }
            );

            modelBuilder.Entity<Videos>()
              .HasOne(v => v.Publisher)
              .WithMany(p => p.Videos)
              .HasForeignKey(v => v.PublisherId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Video)
                .WithMany(v => v.OrderDetails)
                .HasForeignKey(od => od.VideoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>()
             .HasOne(c => c.User)
             .WithMany(u => u.Cart)
             .HasForeignKey(c => c.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Video)
                .WithMany()
                .HasForeignKey(ci => ci.VideoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeedBack>()
                .HasOne(f => f.User)
                .WithMany(u => u.FeedBack)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FeedBack>()
                .HasOne(f => f.Videos)
                .WithMany(v => v.Feedbacks)
                .HasForeignKey(f => f.VideoId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }

}

