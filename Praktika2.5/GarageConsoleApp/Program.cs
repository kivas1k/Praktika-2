using System;

namespace GarageConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");  // Выводим список доступных действий для пользователя
            Console.WriteLine("1. Показать список типов машин");
            Console.WriteLine("2. Добавить тип машины");
            Console.WriteLine("3. Показать список водителей");
            Console.WriteLine("4. Добавить водителя");
            Console.WriteLine("5. Показать список категорий прав водителей");
            Console.WriteLine("6. Добавить категорию прав водителей");
            Console.WriteLine("7. Назначить категорию прав водителю");
            Console.WriteLine("8. Показать список машин");
            Console.WriteLine("9. Добавить машину");
            Console.WriteLine("10. Показать список маршрутов");
            Console.WriteLine("11. Добавить маршрут");
            Console.WriteLine("12. Показать список рейсов");
            Console.WriteLine("13. Добавить рейс");
            Console.WriteLine("0. Выход");

            bool exit = false;

            while (!exit) // Цикл обработки действий пользователя
            {
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DatabaseRequests.GetTypeCarQuery(); // Вызов метода для получения списка типов машин из базы данных
                        break;
                    
                    case "2":
                        Console.Write("Введите название типа машины: ");
                        string typeName = Console.ReadLine();
                        DatabaseRequests.AddTypeCarQuery(typeName); // Вызов метода для добавления нового типа машины в базу данных
                        break;
                    
                    case "3":
                        DatabaseRequests.GetDriverQuery(); // Вызов метода для получения списка водителей из базы данных
                        break;
                    
                    case "4":
                        Console.Write("Введите имя водителя: ");
                        string firstName = Console.ReadLine();
                        
                        Console.Write("Введите фамилию водителя: ");
                        string lastName = Console.ReadLine();
                        
                        Console.Write("Введите дату рождения водителя (гггг-мм-дд): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
                        {
                            DatabaseRequests.AddDriverQuery(firstName, lastName, birthdate); // Вызов метода для добавления нового водителя в базу данных
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат даты!");
                        }
                        break;
                    
                    case "5":
                        Console.Write("Введите ID водителя: ");
                        if (int.TryParse(Console.ReadLine(), out int driverId))
                        {
                            DatabaseRequests.GetDriverRightsCategoryQuery(driverId); // Вызов метода для получения категорий прав водителя из базы данных
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID водителя!");
                        }
                        break;
                    
                    case "6":
                        Console.Write("Введите название категории прав: ");
                        string categoryName = Console.ReadLine();
                        DatabaseRequests.AddRightsCategoryQuery(categoryName); // Вызов метода для добавления новой категории прав водителя в базу данных
                        break;
                    
                    case "7":
                        Console.Write("Введите ID водителя: ");
                        if (int.TryParse(Console.ReadLine(), out int driverIdAssign))
                        {
                            Console.Write("Введите ID категории прав: ");
                            
                            if (int.TryParse(Console.ReadLine(), out int categoryId))
                            {
                                DatabaseRequests.AddDriverRightsCategoryQuery(driverIdAssign, categoryId); // Вызов метода для назначения категории прав водителю в базе данных
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат ID категории прав!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID водителя!");
                        }
                        break;
                    
                    case "8":
                        DatabaseRequests.GetCarQuery(); // Вызов метода для получения списка машин из базы данных
                        break;
                    
                    case "9":
                        Console.Write("Введите ID типа машины: ");
                        if (int.TryParse(Console.ReadLine(), out int typeId))
                        {
                            Console.Write("Введите название машины: ");
                            string carName = Console.ReadLine();
                            
                            Console.Write("Введите штатный номер машины: ");
                            string stateNumber = Console.ReadLine();
                            
                            Console.Write("Введите максимальное количество пассажиров: ");
                            if (int.TryParse(Console.ReadLine(), out int maxPassengers))
                            {
                                DatabaseRequests.AddCarQuery(typeId, carName, stateNumber, maxPassengers);  // Вызов метода для добавления новой машины в базу данных
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат количества пассажиров!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID типа машины!");
                        }
                        break;
                    
                    case "10":
                        DatabaseRequests.GetItineraryQuery(); // Вызов метода для получения списка маршрутов из базы данных
                        break;
                    
                    case "11":
                        Console.Write("Введите название маршрута: ");
                        string itineraryName = Console.ReadLine();
                        DatabaseRequests.AddItineraryQuery(itineraryName);  // Вызов метода для добавления нового маршрута в базу 
                        break;
                    
                    case "12":
                        DatabaseRequests.GetRouteQuery(); // Вызов метода для получения списка рейсов из базы данных
                        break;
                    
                    case "13":
                        Console.Write("Введите ID водителя: ");
                        if (int.TryParse(Console.ReadLine(), out int driverIdTrip))
                        {
                            Console.Write("Введите ID машины: ");
                            if (int.TryParse(Console.ReadLine(), out int carId))
                            {
                                Console.Write("Введите ID маршрута: ");
                                if (int.TryParse(Console.ReadLine(), out int itineraryId))
                                {
                                    Console.Write("Введите количество пассажиров: ");
                                    if (int.TryParse(Console.ReadLine(), out int passengers))
                                    {
                                        DatabaseRequests.AddRouteQuery(driverIdTrip, carId, itineraryId, passengers); // Вызов метода для добавления нового рейса в базу данных
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат количества пассажиров!");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат ID маршрута!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Неверный формат ID машины!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат ID водителя!");
                        }
                        break;
                    
                    case "0":
                        exit = true;
                        break;
                    
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
