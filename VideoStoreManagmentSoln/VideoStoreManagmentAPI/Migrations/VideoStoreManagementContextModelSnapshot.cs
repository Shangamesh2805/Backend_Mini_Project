﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoStoreManagmentAPI.Contexts;

#nullable disable

namespace VideoStoreManagmentAPI.Migrations
{
    [DbContext(typeof(VideoStoreManagementContext))]
    partial class VideoStoreManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1")
                        .IsUnique()
                        .HasFilter("[UserId1] IS NOT NULL");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("VideoId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.FeedBack", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("VideoId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            PublisherName = "Warner Bros"
                        },
                        new
                        {
                            PublisherId = 2,
                            PublisherName = "20th Century Fox"
                        });
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeviceLimit")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountFactor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Membership")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Age = 25,
                            DeviceLimit = 1,
                            DiscountFactor = 0m,
                            Email = "tojo@gmai.com",
                            Membership = 0,
                            Name = "Tojo"
                        },
                        new
                        {
                            UserId = 2,
                            Age = 17,
                            DeviceLimit = 2,
                            DiscountFactor = 2m,
                            Email = "tanjiro@gmail.com",
                            Membership = 1,
                            Name = "Tanjiro"
                        });
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Videos", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideoId"), 1L, 1);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoFormat")
                        .HasColumnType("int");

                    b.HasKey("VideoId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            VideoId = 1,
                            Availability = true,
                            Description = "A mind-bending thriller",
                            Genre = "Sci-Fi",
                            Price = 9.99m,
                            PublisherId = 1,
                            Title = "Inception",
                            VideoFormat = 0
                        },
                        new
                        {
                            VideoId = 2,
                            Availability = true,
                            Description = "A hacker discovers reality",
                            Genre = "Action",
                            Price = 14.99m,
                            PublisherId = 2,
                            Title = "The Matrix",
                            VideoFormat = 1
                        });
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Cart", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoStoreManagmentAPI.Models.User", null)
                        .WithOne("Cart")
                        .HasForeignKey("VideoStoreManagmentAPI.Models.Cart", "UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.CartItem", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoStoreManagmentAPI.Models.Videos", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.FeedBack", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.User", "User")
                        .WithMany("FeedBack")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("VideoStoreManagmentAPI.Models.Videos", "Videos")
                        .WithMany("Feedbacks")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.OrderDetails", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoStoreManagmentAPI.Models.Videos", "Video")
                        .WithMany("OrderDetails")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Orders", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Videos", b =>
                {
                    b.HasOne("VideoStoreManagmentAPI.Models.Publisher", "Publisher")
                        .WithMany("Videos")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Publisher", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("FeedBack");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("VideoStoreManagmentAPI.Models.Videos", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
