using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Repositories;
using VideoStoreManagmentAPI.Services;
using VideoStoreManagmentAPI.Services.Interfaces;

namespace VideoStoreManagmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoStoreManagementAPI", Version = "v1" });
            });


            builder.Services.AddDbContext<VideoStoreManagementContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            );

            //repos
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Cart>, CartRepository>();
            builder.Services.AddScoped<IRepository<int, CartItem>, CartItemRepository>();
            builder.Services.AddScoped<IRepository<int, FeedBack>, FeedbackRepository>();
            builder.Services.AddScoped<IRepository<int, Orders>, OrderRepository>();
            builder.Services.AddScoped<IRepository<int, OrderDetails>, OrderDetailRepository>();
            builder.Services.AddScoped<IRepository<int, Videos>, VideoRepository>();
            builder.Services.AddScoped<IRepository<int, Publisher>, PublisherRepository>();

            



            // Add services
            builder.Services.AddScoped<IVideoService, VideoService>();
            builder.Services.AddScoped<ICartServices, CartServices>();
            
            

            // authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequirePublisherRole", policy => policy.RequireRole("Publisher"));
                options.AddPolicy("RequireNormalUserRole", policy => policy.RequireRole("NormalUser"));
                options.AddPolicy("RequireGoldenMemberRole", policy => policy.RequireRole("GoldenMember"));
            });


            #region contexts
            builder.Services.AddDbContext<VideoStoreManagementContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}