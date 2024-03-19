﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Service.Customers.Implementation;
using PaymentAndDiscountCardSystemDAL.CustomerRepository;
using PaymentAndDiscountCardSystemDAL.DiscountCardRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemService.Cards.Implementation;
using PaymentAndDiscountCardSystemService.Cards.Interfaces;
using PaymentAndDiscountCardSystemService.Customers.Implementation;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;
using Serilog;
using System.Runtime.CompilerServices;

namespace PaymentAndDiscountCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var customerRepositoryList = new List<Customer>();

            var log = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}", "Log.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            var log1 = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

            var services = new ServiceCollection()
    .AddSingleton<ICustomerRepository>(serviceProvider =>
    {
        return new CustomerRepository();
    })
    .AddSingleton<IDiscountCardRepository,DiscountCardRepository>()
    .AddSingleton<ICreateCustomerService,CreateCustomerService>()
    .AddSingleton<IGetCustomerService, GetCustomerService>()
    .AddSingleton<ICustomerService, CustomerService>()
    .AddSingleton<IAddCardService, AddCardService>()
    .AddSingleton<IPurchaseService, PurchaseService>()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.AddSerilog(log);
    });




            using var serviceProvider = services.BuildServiceProvider();

            //Define the path to the text file
            string logFilePath = "console_log.txt";

            //Create a StreamWriter to write logs to a text file
            using (StreamWriter logFileWriter = new StreamWriter(logFilePath, append: true))
            {
                //Create an ILoggerFactory
                ILoggerFactory loggerFactoryFile = LoggerFactory.Create(builder =>
                {
                    //Add console output
                    builder.AddSimpleConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "HH:mm:ss ";
                    });

                    //Add a custom log provider to write logs to text files
                    builder.AddProvider(new CustomFileLoggerProvider(logFileWriter));
                });

                //Create an ILogger
                ILogger<Program> logger = loggerFactoryFile.CreateLogger<Program>();

                // Output some text on the console
                using (logger.BeginScope("[scope is enabled]"))
                {
                    logger.LogInformation("Hello World!");
                    logger.LogInformation("Logs contain timestamp and log level.");
                    logger.LogInformation("Each log message is fit in a single line.");
                }
            }





            //Initializing console logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => // Шо за логгер Factory
            {
                builder.AddConsole();
            });


            //Services
            var customerService = serviceProvider.GetService<ICustomerService>();

            IGetCustomerService getCustomerService = serviceProvider.GetService<IGetCustomerService>();
            ICreateCustomerService createCustomerService = serviceProvider.GetService<ICreateCustomerService>();
            IPurchaseService purchaseService = serviceProvider.GetService<IPurchaseService>();
            IAddCardService addCardService = serviceProvider.GetService<IAddCardService>();

            Customer customer1 = new Customer("Dima");
            createCustomerService.Add(customer1);
            addCardService.ToCustomer(customer1, DiscountCardType.Tube);
            addCardService.ToCustomer(customer1, DiscountCardType.Tube);
            addCardService.ToCustomer(customer1, DiscountCardType.Tube);
            //var  = customerService.GetByName("Dima");

            Guid authorizedUserId = Autorization(getCustomerService, createCustomerService);

            while (true)
            {
                Console.WriteLine("Главное меню. Нажмите Enter");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                if (keyInfo.Key != ConsoleKey.Escape)
                {
                    Console.Write("Выберите действие:\n" +
                        "1.Начать покупки\n" +
                        "2.Выдать веселую карту\n" +
                        "3.Аннулировать циклическую карту\n" +
                        //   "4.Данные о картах магазина\n" +
                        //     "5.Данные о пользователе\n" +
                        "4.Данные о пользователе\n" +
                        "Введите цифру действия и нажмите Enter: ");
                    string writingMess = Console.ReadLine();
                    Console.Clear();
                    switch (writingMess)
                    {
                        case "1":
                            RunSession(() => ProcessPurchase(authorizedUserId, purchaseService));
                            break;
                        case "2":
                            var customer = getCustomerService.GetById(authorizedUserId);
                            customerService.GetCustomerFunnyCard(customer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Клиенту {customer.Name} выдана веселая карта");
                            Console.ResetColor();
                            break;
                        case "3":
                            Console.WriteLine();
                            break;
                        case "4":
                            Console.WriteLine();
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Клавиша Escape нажата. Программа завершает работу.");
                    break;
                }
            }
        }

        private static Guid Autorization(IGetCustomerService getCustomerService, ICreateCustomerService createCustomerService)
        {
            const int minLengthSize = 2;

            Console.Write("Введите имя клиента: ");
            var name = Console.ReadLine();

            while (name.Length <= minLengthSize)
            {
                Console.WriteLine($"Имя должно быть больше {minLengthSize} символова");
                Console.Write("Введите имя клиента: ");
                name = Console.ReadLine();

            }
            var customer = getCustomerService.GetByName(name);

            if (customer != null)
            {
                Console.WriteLine($"HI {customer.Name} | {customer.AccumulatedAmount} $");
            }
            else
            {
                createCustomerService.Add(new Customer(name));
                customer = getCustomerService.GetByName(name);
                Console.WriteLine($"Hello {customer.Name} | {customer.AccumulatedAmount} $");
            }

            return customer.Id;
        }

        private static void ProcessPurchase(Guid id, IPurchaseService purchaseService)
        {
            if (purchaseService is null)
            {
                throw new ArgumentNullException(nameof(purchaseService));
            }

            decimal amount;

            Console.Write("Введите сумму: ");
            // Считываем ввод пользователя и пытаемся преобразовать его в десятичное число
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                purchaseService.Purchase(id, amount);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное десятичное число.");
            }
        }

        private static void RunSession(params Action[] actions)
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Escape)
                {
                    foreach (var action in actions)
                    {
                        action(); // Выполняем все переданные функции
                    }
                }
                else
                {
                    Console.WriteLine("Возвращение на главное меню. Нажмите Enter");
                    break;
                }

            }
        }

        // Customized ILoggerProvider, writes logs to text files
        public class CustomFileLoggerProvider : ILoggerProvider
        {
            private readonly StreamWriter _logFileWriter;

            public CustomFileLoggerProvider(StreamWriter logFileWriter)
            {
                _logFileWriter = logFileWriter ?? throw new ArgumentNullException(nameof(logFileWriter));
            }

            public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
            {
                return new CustomFileLogger(categoryName, _logFileWriter);
            }

            public void Dispose()
            {
                _logFileWriter.Dispose();
            }
        }

        // Customized ILogger, writes logs to text files
        public class CustomFileLogger : Microsoft.Extensions.Logging.ILogger
        {
            private readonly string _categoryName;
            private readonly StreamWriter _logFileWriter;

            public CustomFileLogger(string categoryName, StreamWriter logFileWriter)
            {
                _categoryName = categoryName;
                _logFileWriter = logFileWriter;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                // Ensure that only information level and higher logs are recorded
                return logLevel >= LogLevel.Information;
            }

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception exception,
                Func<TState, Exception, string> formatter)
            {
                // Ensure that only information level and higher logs are recorded
                if (!IsEnabled(logLevel))
                {
                    return;
                }

                // Get the formatted log message
                var message = formatter(state, exception);

                //Write log messages to text file
                _logFileWriter.WriteLine($"[{logLevel}] [{_categoryName}] {message}");
                _logFileWriter.Flush();
            }
        }
        public class SetupLogging
        {
            [ModuleInitializer]
            public static void Init()
            {
                Initialize();
            }
            public static void Initialize()
            {

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}", "Log.txt"),
                        rollingInterval: RollingInterval.Infinite,
                        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                    .CreateLogger();
            }
        }
    }
}
