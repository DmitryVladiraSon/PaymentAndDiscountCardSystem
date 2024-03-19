using Microsoft.Extensions.DependencyInjection;
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
            var startup = new Startup();
            startup.ConfigureServices();

            //Initializing console logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => // Шо за логгер Factory
            {
                builder.AddConsole();
            });
            //Services Customers
            var getCustomerService = startup.ServiceProvider.GetService<IGetCustomerService>();
            var createCustomerService = startup.ServiceProvider.GetService<ICreateCustomerService>();
            var purchaseService = startup.ServiceProvider.GetService<IPurchaseService>();
            //Card services
            var addCardService = startup.ServiceProvider.GetService<IAddCardService>();
            var hasCardService = startup.ServiceProvider.GetService<IHasCardService>();
            var deleteCardService = startup.ServiceProvider.GetService<IDeleteCardService>();
            var dataInitializer = startup.ServiceProvider.GetService<DataInitializer>();

            dataInitializer.Initialize();

            while (true)
            {
                Console.WriteLine("Authorization. Press Enter");
                ConsoleKeyInfo authorizationKeyInfo = Console.ReadKey(true);
                Console.Clear();
                if (authorizationKeyInfo.Key != ConsoleKey.Escape)
                {
                    Guid authorizedUserId = Autorization(getCustomerService, createCustomerService);
                    bool mainMenuSession = true;
                    var customer = getCustomerService.GetById(authorizedUserId);

                    while (mainMenuSession)
                    {
                        
                        Console.WriteLine("The main menu. Press Enter");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        Console.Clear();
                        if (keyInfo.Key != ConsoleKey.Escape)
                        {
                            Console.Write("Choose an action:\n" +
                                            "1.Start shopping\n" +
                                            "2.Issue/pick up a card a FUNNY card\n" +
                                            "3.Issue/pick up a card a QUANTUM card\n" +
                                            "4.User information \n" +
                                            "5.Go to Authorization\n" +
                                            "Enter the action number and press Enter:");
                            string writingMess = Console.ReadLine();
                            Console.Clear();
                            switch (writingMess)
                            {
                                case "1": //Start shopping
                                    RunSession(() => ProcessPurchase(authorizedUserId, purchaseService));
                                    break;
                                case "2": //Issue/pick up a card a fun card
                                    IssueOrPickUpCardFromCustomer(customer, DiscountCardType.FunnyCard, hasCardService, deleteCardService, addCardService);
                                    break;
                                case "3": //Issue/pick up a card a QUANTUM card
                                    IssueOrPickUpCardFromCustomer(customer, DiscountCardType.Quantum, hasCardService, deleteCardService, addCardService);
                                    break;
                                case "4": //User information
                                    Console.WriteLine($"{customer.Name}");
                                    Console.WriteLine($"{customer.AccumulatedAmount}");
                                    Console.WriteLine($"Cards:");
                                    foreach (Card card in customer.Cards)
                                    {
                                        Console.WriteLine($"{card.Type} {card.DiscountRate}");
                                    }
                                    break;
                                case "5": //Go to autorization
                                    mainMenuSession = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Клавиша Escape нажата. Return to Authorization");
                            break;
                        }
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

            Console.Write("Enter the client's name: ");
            var name = Console.ReadLine();

            while (name.Length <= minLengthSize)
            {
                Console.WriteLine($"The name must be more than {minLengthSize} characters");
                Console.Write("Enter the client's name: ");
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
                Console.WriteLine($"Hello new customer! {customer.Name}");
            }

            return customer.Id;
        }

        private static void ProcessPurchase(Guid CustomerId, IPurchaseService purchaseService)
        {
            if (purchaseService is null)
            {
                throw new ArgumentNullException(nameof(purchaseService));
            }

            decimal amount;
            
            Console.Write("Enter the amount: ");
            // Считываем ввод пользователя и пытаемся преобразовать его в десятичное число
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                purchaseService.Purchase(CustomerId, amount);
                Console.Write("Description about customer and operation");
            }
            else
            {
                Console.WriteLine("Incorrect input. Please enter a positive decimal number.");
            }
        }

        private static void RunSession(params Action[] actions)
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    foreach (var action in actions)
                    {
                        action(); 
                    }
                }
                else
                {
                    Console.WriteLine("Return to the main menu. Press Enter");
                    break;
                }
            }
        }

        private static void IssueOrPickUpCardFromCustomer(Customer customer, DiscountCardType gettingCardType, IHasCardService hasCardService, IDeleteCardService deleteCardService, IAddCardService addCardService)
        {
            if (hasCardService.FromCustomer(customer, gettingCardType))
            {
                deleteCardService.FromCustomer(customer, gettingCardType);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"To the client {customer.Name} the card {gettingCardType} has been deleted");
                Console.ResetColor();
            }
            else
            {
                addCardService.ToCustomer(customer, gettingCardType);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"To the client {customer.Name} a card {gettingCardType} has been issued");
                Console.ResetColor();
            }
        }
    }
}
