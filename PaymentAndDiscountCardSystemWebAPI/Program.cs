
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentAndDiscountCardSystemDAL;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemService.Cards.Implementation;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using System.Text.Json.Serialization;

namespace PaymentAndDiscountCardSystemWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerCreationService, CustomerCreationService>();
            builder.Services.AddScoped<ICustomerQueryService, CustomerQueryService>();
            builder.Services.AddScoped<IAddCardService, AddCardService>();
            builder.Services.AddScoped<IDeleteCardService, DeleteCardService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
