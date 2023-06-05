using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp
{
    public class UserCommunication : IUserCommunication
    {
        private IRepository<Car> _carsRepository;
        private ICarsProvider _carsProvider;
        public UserCommunication(IRepository<Car> carsRepository, ICarsProvider carsProvider)
        {
            _carsRepository = carsRepository;
            _carsProvider = carsProvider;
        }

        public void ChooseAction()
        {
            bool isRunning = true;
            
            while (isRunning)
            {
                Console.WriteLine("""
                    Please choose action:
                    a - add car
                    g - generate sample of cars and add them
                    r - remove car
                    v - view all cars
                    f - filter cars
                    q - quit and save
                    """);

                var input = GetNotEmptyInput("Type in a letter here:");
                
                switch(input.ToLower())
                {
                    case "v":
                        ViewAllCars();
                        break;
                    case "g":
                        GenerateAndAddSampleCars();
                        break;
                    case "q":
                        isRunning = CloseApp(_carsRepository);
                        break;
                    default: Console.WriteLine("Invalid input");
                        continue;
                }
                
            }
        }

        
        private void ViewAllCars()
        {
            var cars = _carsRepository.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }


        public string GetNotEmptyInput(string quest)
        {
            Console.WriteLine(quest);
            var input = Console.ReadLine();

            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("The input can not be empty");
                input = Console.ReadLine();
            }
            return input;
        }

        private void GenerateAndAddSampleCars()
        {
            var cars = GenerateSampleCars();

            foreach (var car in cars)
            {
                _carsRepository.Add(car);
            }
        }

        private List<Car> GenerateSampleCars()
        {
            return new List<Car>()
            {
                new Car { Id = 1, Name = "Ford", Color = "Red", StandardCost = 10000.00m, ListPrice = 15000.00m, Type = "Sedan" },
                new Car { Id = 2, Name = "Fiat", Color = "Blue", StandardCost = 12000.00m, ListPrice = 18000.00m, Type = "Convertible" },
                new Car { Id = 3, Name = "Mazda", Color = "Green", StandardCost = 8000.00m, ListPrice = 13000.00m, Type = "SUV" },
                new Car { Id = 4, Name = "Mercedes", Color = "Yellow", StandardCost = 15000.00m, ListPrice = 20000.00m, Type = "Sports Car" },
                new Car { Id = 5, Name = "Stelantis", Color = "Black", StandardCost = 9000.00m, ListPrice = 14000.00m, Type = "Hatchback" },
                new Car { Id = 6, Name = "BMW", Color = "White", StandardCost = 11000.00m, ListPrice = 17000.00m, Type = "Coupe" },
                new Car { Id = 7, Name = "Toyota", Color = "Gray", StandardCost = 10000.00m, ListPrice = 16000.00m, Type = "Sedan" },
                new Car { Id = 8, Name = "Lexus", Color = "Silver", StandardCost = 9600.00m, ListPrice = 14000.00m, Type = "SUV" },
                new Car { Id = 9, Name = "Buick", Color = "Green", StandardCost = 9500.00m, ListPrice = 14000.00m, Type = "SUV" }
            };
        }

        private bool CloseApp(IRepository<Car> carsRepository)
        {
            while (true)
            {
                var choice = GetNotEmptyInput("Do you want to save changes on exit?\nType y if yes\t\tType n if no").ToUpper();
                if (choice == "Y")
                {
                    carsRepository.Save();
                    Console.WriteLine("Changes successfully saved.", ConsoleColor.Green);
                    return false;
                }
                else if (choice == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose yes or no:", ConsoleColor.Red);
                }
            }
        }


    }
}
