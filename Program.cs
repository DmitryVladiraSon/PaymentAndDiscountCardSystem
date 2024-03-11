﻿using Microsoft.Extensions.Logging;

using PaymentAndDiscountCardSystem.Shop;
using PaymentAndDiscountCardSystem.Shop.Cards;
using PaymentAndDiscountCardSystem.Users;
using ClassLibrary.Domain;
using ClassLibrary.Domain.Service;

namespace PaymentAndDiscountCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            CustomerService customerService = new CustomerService(loggerFactory.CreateLogger<CustomerService>());

            ClassLibrary.Domain.Models.Customer customer1 = new ClassLibrary.Domain.Models.Customer() ;
            customerService.Add(customer1);

            var store = new Store();
            
            AddingCardsInStore(store);
            AddingCustomerWith15000Balace(store, new Customer("Dima"));
            store.GetCustomerFunnyCard(store.GetCustomer("Dima"));

            string authorizedUserName = Autorization(store);


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
                            RunSession(() => ProcessPurchase(store, authorizedUserName));
                            break;
                        case "2":
                            var customer = store.GetCustomer(authorizedUserName);
                            store.GetCustomerFunnyCard(customer);
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

        static string Autorization(Store store)
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
            var customer = store.GetCustomer(name);

            if (customer != null)
            {
                Console.WriteLine($"HI {customer.Name} | {customer.AccumulatedAmount} $");
            } 
            else
            { 
                store.AddCustomer(new Customer(name));
                customer = store.GetCustomer(name);
                Console.WriteLine($"Hello {customer.Name} | {customer.AccumulatedAmount} $");

            }

            return name;
        }

        static void ProcessPurchase(Store store, string CustomerName)
        {
            decimal amount;
            
            Console.Write("Введите сумму: ");

            // Считываем ввод пользователя и пытаемся преобразовать его в десятичное число
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
            {
                store.ProcessPurchase(store.GetCustomer(CustomerName), amount);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное десятичное число.");
            }
        }



        static void RunSession(Func<Store, string> authorizationFunc, out string authorizedUserName, Store store)
        {
            authorizedUserName = authorizationFunc(store);
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

        static void AddingCardsInStore(Store store)
        {
            store.AddCard(new DiscountCard(TypeDiscountCard.Tube, 5000, 5));
            store.AddCard(new DiscountCard(TypeDiscountCard.Transistor, 12500, 10));
            store.AddCard(new DiscountCard(TypeDiscountCard.Integrated, 25000, 15));
            store.AddCard(new DiscountCard(TypeDiscountCard.Transistor, 12500, 10));

            //Добавь веселую карту 
            store.AddCard(new FunnyCard(TypeDiscountCard.Cheerful, 10));

            //Добавление кватновой карты
            store.AddCard(new QuantumCard(TypeDiscountCard.Quantum, 20));
            //Console.ReadKey();
            //Console.Clear();
        }

        static void AddingCustomerWith15000Balace(Store store, Customer customer)
        {
            store.AddCustomer(customer);

            store.ProcessPurchase(store.GetCustomer(customer.Name), 15000);
        }
    }
}
