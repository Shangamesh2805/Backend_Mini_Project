using Microsoft.EntityFrameworkCore;
using VideoStoreManagmentAPI.Models;

namespace VideoStoreManagmentAPI.Contexts
{
    public class VideoStoreManagementContext : DbContext
    {
        public VideoStoreManagementContext(DbContextOptions<VideoStoreManagementContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Videos> Videos { get; set; }
        
        public DbSet<Payment>Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Videos)
                .WithOne(v => v.Publisher)
                .HasForeignKey(v => v.PublisherId);

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
                .WithMany()
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

            modelBuilder.Entity<Payment>()
               .HasOne(p => p.Order)
               .WithOne(o => o.Payment)
               .HasForeignKey<Payment>(p => p.OrderId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
