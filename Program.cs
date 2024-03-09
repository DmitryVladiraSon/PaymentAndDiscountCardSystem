using PaymentAndDiscountCardSystem.Shop;
using PaymentAndDiscountCardSystem.Shop.Cards;
using PaymentAndDiscountCardSystem.Users;
using System;

namespace PaymentAndDiscountCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var store = new Store();
            
            AddingCardsInStore(store);
            AddingCustomerWith15000Balace(store, new Customer("Dima"));
            store.GetCustomerFunnyCard(store.GetCustomer("Dima"));
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Escape)
                {
                    RunSession(Autorization, out string authorizedUserName, store);

                    RunSession(() => ProcessPurchase(store, authorizedUserName));
                }
                else
                {
                    Console.WriteLine("Клавиша Escape нажата. Программа завершает работу.");
                    break; // Выход из цикла
                }
            }
            
            //Выдача веселой карты 

            
        }

        static string Autorization(Store store)
        {
            Console.Write("Введите имя клиента: ");
            var name = Console.ReadLine();
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
            if (decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                store.ProcessPurchase(store.GetCustomer(CustomerName), amount);
            }
            else
            {
                // В случае некорректного ввода
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите десятичное число.");
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
                    Console.WriteLine("Клавиша Escape нажата. Возвращение на главное меню.Нажмите Enter");
                    break; // Выход из цикла
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


//Нужно чтобы приоритет вводился НЕ в ручную. Может получиться конфликт приоритета. Это нужно исправить. Например. Ошибка = приоритет.1 приоритет.1


//while (true)
//{
//    // Ожидание нажатия клавиши
//    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

//    // Проверка, является ли нажатая клавиша Escape
//    if (keyInfo.Key != ConsoleKey.Escape)
//    {
//        string authorizationUserName = Autorization(Store);

//        while (true)
//        {
//            ConsoleKeyInfo keyInfoIn = Console.ReadKey(true);

//            if (keyInfoIn.Key == ConsoleKey.Escape)
//            {
//                Console.WriteLine("Клавиша Escape нажата. Программа завершает работу.");
//                break; // Выход из цикла
//            }

//            ProcessPurchase(Store, authorizationUserName);
//        }

//    }
//    else
//    {
//        Console.WriteLine("Клавиша Escape нажата. Программа завершает работу.");
//        break; // Выход из цикла

//    }
//}

