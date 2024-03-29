﻿using Microsoft.Extensions.DependencyInjection;
using PaymentAndDiscountCardSystem.Service.Customers.Implementation;
using PaymentAndDiscountCardSystemDAL.CustomerRepository;
using PaymentAndDiscountCardSystemDAL.DiscountCardRepository;
using PaymentAndDiscountCardSystemService.Cards.Implementation;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem
{
    public class Startup
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ICustomerRepository>(serviceProvider =>
            {
                return new CustomerRepository();
            });
            serviceCollection.AddSingleton<IDiscountCardRepository, DiscountCardRepository>();
            serviceCollection.AddSingleton<ICreateCustomerService, CreateCustomerService>();
            serviceCollection.AddSingleton<IGetCustomerService, GetCustomerService>();
            serviceCollection.AddSingleton<IAddCardService, AddCardService>();
            serviceCollection.AddSingleton<IHasCardService, HasCardService>();
            serviceCollection.AddSingleton<IDeleteCardService, DeleteCardService>();
            serviceCollection.AddSingleton<IPurchaseService, PurchaseService>();
            serviceCollection.AddSingleton<DataInitializer>();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(logger);
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
