using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Entity;
using PaymentAndDiscountCardSystem.Domain.Entity.Cards;
using PaymentAndDiscountCardSystem.Service.Implementation;
using PaymentAndDiscountCardSystem.Service.Interfaces;

namespace PaymentAndDiscountCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<List<Customer>>() // Delete THIS SHIT
            .AddLogging();

            using var providerService = services.BuildServiceProvider();

            List<Customer> customers = new List<Customer>(); // This is storage/repository
            Customer[] arrayCust = new Customer[1];
           
            //Initializing console logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            { 
                builder.AddConsole();
            });

            
            //Services
         //    CustomerService customerService = new CustomerService(customers, loggerFactory.CreateLogger<CustomerService>());
             var customerService = providerService.GetService<ICustomerService>();
            PurchaseService purchaseService = new PurchaseService();
           // CustomerService customerService1 = new CustomerService(arrayCust,loggerFactory.CreateLogger<CustomerService>());

            Customer customer1 = new Customer("Dima", "pass") ;
            customerService.Add(customer1);

           var authorizedUserId = customerService.GetByName("Dima");


            
           // AddingCardsInStore(store);
           // AddingCustomerWith15000Balace(store, new Customer("Dima","pass"));

            string authorizedUserName = Autorization(customerService);


            while (true)
            {
                Console.WriteLine("Главное меню. Нажмите Enter");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                if (keyInfo.Key != ConsoleKey.Escape)
                {
                    //RunSession(Autorization, out string authorizedUserName, store);

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
                            RunSession(() => ProcessPurchase(customers, authorizedUserId));
                            break;
                        case "2":
                            var customer = customerService.GetByName(authorizedUserName);
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

        static string Autorization(ICustomerService customerService)
        {
           

            int  MIN_LENGHT_NAME = 2;

            Console.Write("Введите имя клиента: ");
            var name = Console.ReadLine();

            while (name.Length <= MIN_LENGHT_NAME)
            {
                Console.WriteLine($"Имя должно быть больше {MIN_LENGHT_NAME} символова");
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

            return name;
        }

        static void ProcessPurchase(List<Customer> customers, Customer customer)
        {
            decimal amount;
            
            Console.Write("Введите сумму: ");
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            CustomerService customerService1 = new CustomerService(customers);//, loggerFactory.CreateLogger<CustomerService>());
            PurchaseService purchaseService = new PurchaseService();
            // Считываем ввод пользователя и пытаемся преобразовать его в десятичное число
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                purchaseService.Purchase(customer, amount);
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
