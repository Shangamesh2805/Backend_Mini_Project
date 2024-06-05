<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using VideoStoreManagmentAPI.Contexts;
using VideoStoreManagmentAPI.Interfaces;
using VideoStoreManagmentAPI.Models;
using VideoStoreManagmentAPI.Repositories;
using VideoStoreManagmentAPI.Repositories.Interfaces;
using VideoStoreManagmentAPI.Services;
using VideoStoreManagmentAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
<<<<<<< HEAD
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
=======
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
<<<<<<< HEAD
    {
        {
            new OpenApiSecurityScheme
=======
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
    {
        {
<<<<<<< HEAD
            new OpenApiSecurityScheme
=======
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
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
<<<<<<< HEAD
    });
});


=======
<<<<<<< HEAD
    });
});

>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
// Register DbContext
builder.Services.AddDbContext<VideoStoreManagementContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
<<<<<<< HEAD
builder.Services.AddScoped<IVideoRepository, VideoRepository>(); 
builder.Services.AddScoped<IFeedBackRepository, FeedBackRepository>();
builder.Services.AddScoped<ICartRepository,CartRepository>();
=======
builder.Services.AddScoped<IVideoRepository, VideoRepository>(); // Register IVideoRepository
builder.Services.AddScoped<IFeedBackRepository, FeedBackRepository>();
builder.Services.AddScoped<IRepository<int, Cart>, CartRepository>();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
builder.Services.AddScoped<IRepository<int, CartItem>, CartItemRepository>();
builder.Services.AddScoped<IRepository<int, Orders>, OrderRepository>();
builder.Services.AddScoped<IRepository<int, OrderDetails>, OrderDetailRepository>();


// Register services
builder.Services.AddScoped<IVideoService, VideoService>(); // Register IVideoService
<<<<<<< HEAD
builder.Services.AddScoped<ICartService, CartService>();
=======
builder.Services.AddScoped<ICartServices, CartServices>();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailsService>();
builder.Services.AddScoped<IOrderServices, OrderService>();
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IFeedBackService, FeedbackService>();

// Configure authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Configure authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequirePublisherRole", policy => policy.RequireRole("Publisher"));
    options.AddPolicy("RequireCustomerRole", policy => policy.RequireRole("Customer"));
    options.AddPolicy("RequireGoldenMemberRole", policy => policy.RequireRole("GoldenMember"));
});

<<<<<<< HEAD

    var app = builder.Build();
=======
var app = builder.Build();
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
<<<<<<< HEAD
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
=======
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
=======
    }
}
>>>>>>> bd4204c8c946b21398d905657cee916787fdeef7
>>>>>>> 1bdab59f01efd5fb7b75e39fa560bd02c36cfa74
