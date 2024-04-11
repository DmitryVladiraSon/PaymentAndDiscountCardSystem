using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentAndDiscountCardSystemDAL;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.ProductRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.UserRepository;
using PaymentAndDiscountCardSystemInfrastructure;
using PaymentAndDiscountCardSystemService.Auth;
using PaymentAndDiscountCardSystemService.Cards.Implementation;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using PaymentAndDiscountCardSystemService.OrderItems;
using PaymentAndDiscountCardSystemService.Orders;
using PaymentAndDiscountCardSystemService.Products;
using PaymentAndDiscountCardSystemService.Users;
using PaymentAndDiscountCardSystemWebAPI.Data;
using PaymentAndDiscountCardSystemWebAPI.Extensions;
using System.Text.Json.Serialization;

namespace PaymentAndDiscountCardSystemWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(StoreDbContext)));
                });

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
            var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            builder.Services.AddApiAuthentication(Options.Create(jwtOptions));

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerCreationService, CustomerCreationService>();
            builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
            builder.Services.AddScoped<IAddCardService, AddCardService>();
            builder.Services.AddScoped<IDeleteCardService, DeleteCardService>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<DataInitializer>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            
            
            builder.Services.AddHttpContextAccessor();


            //var serviceProvider = builder.Services.BuildServiceProvider();
            //var dataInitializer = serviceProvider.GetRequiredService<DataInitializer>();
            //dataInitializer.Initialize();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
