using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.DAL.Interfaces;
using PaymentAndDiscountCardSystem.DAL.Repositories;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Service.Implementation;
using PaymentAndDiscountCardSystem.Service.Interfaces;

namespace PaymentAndDiscountCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection() 
                .AddSingleton<ICustomerRepository,CustomerRepository>()
                .AddSingleton<ICustomerService, CustomerService>()
                .AddSingleton<IPurchaseService,PurchaseService>()
                .AddSingleton<List<Customer>>() // Delete THIS ?
                //Adding logging in Dep.Inj.
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            });

            using var providerService = services.BuildServiceProvider();

            //Initializing console logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => // Шо за логгер Factory
            { 
                builder.AddConsole();
            });

            
            //Services
             var customerService = providerService.GetService<ICustomerService>();
            IPurchaseService purchaseService = providerService.GetService<IPurchaseService>();

            Customer customer1 = new Customer("Dima", "pass") ;
            customerService.Add(customer1);

           //var  = customerService.GetByName("Dima");

            Guid authorizedUserId = Autorization(customerService);

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
                            var customer = customerService.GetById(authorizedUserId);
                            customerService.GetCustomerFunnyCard(customer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Клиенту {customer.Name} выдана веселая карта");
                            Console.ResetColor();
                            break;
                        case "3":
                            Console.WriteLine( );
                            break;
                        case "4":
                            Console.WriteLine( );
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

        static Guid Autorization(ICustomerService customerService)
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
            var customer = customerService.GetByName(name); 

            if (customer != null)
            {
                Console.WriteLine($"HI {customer.Name} | {customer.AccumulatedAmount} $");
            } 
            else
            { 
                customerService.Add(new Customer(name,"pass"));
                customer = customerService.GetByName(name);
                Console.WriteLine($"Hello {customer.Name} | {customer.AccumulatedAmount} $");
            }
           
            return customer.Id;
        }

        static void ProcessPurchase(Guid id, IPurchaseService purchaseService)
        {
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




        static void RunSession(params Action[] actions)
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

    }
}
