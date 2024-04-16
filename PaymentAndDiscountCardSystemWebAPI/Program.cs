using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentAndDiscountCardSystemBLL.Auth;
using PaymentAndDiscountCardSystemDAL;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderItemRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.OrderRepository;
using PaymentAndDiscountCardSystemDAL.Repositories.ProductRepository;
using PaymentAndDiscountCardSystemInfrastructure;
using PaymentAndDiscountCardSystemBLL.Auth;
using PaymentAndDiscountCardSystemService.Cards;
using PaymentAndDiscountCardSystemBLL.Cards.Implementation;
using PaymentAndDiscountCardSystemBLL.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemBLL.Customers.Interfaces;
using PaymentAndDiscountCardSystemBLL.OrderItems;
using PaymentAndDiscountCardSystemBLL.Orders;
using PaymentAndDiscountCardSystemBLL.Products;
using PaymentAndDiscountCardSystemWebAPI.Data;
using PaymentAndDiscountCardSystemWebAPI.Extensions;
using System.Text.Json.Serialization;
using PaymentAndDiscountCardSystemBLL.Customers.Implementation;

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

            builder.Services.AddScoped<ILoginService, LoginService>();
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
