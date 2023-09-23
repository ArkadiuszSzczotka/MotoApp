using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotoApp.Services;

public class UserCommunication : IUserCommunication
{
    private readonly IRepository<Car> _carsRepository;
    private readonly IDataGenerator _dataGenerator;
    private readonly ICarsProvider _carsProvider;
    public UserCommunication(IRepository<Car> carsRepository, ICarsProvider carsProvider, IDataGenerator dataGenerator)
    {
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
        _dataGenerator = dataGenerator;
    }


    public void ChooseAction()
    {
        WriteColorLine("Welcome to AAutoStore", ConsoleColor.Green);

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("""
                    Please choose action:
                    a - add car
                    g - generate sample of cars and add them
                    r - remove car
                    v - view all cars
                    c - view all cars (cheap) sorted by price descending
                    f - filter cars
                    s - search car by ID
                    q - quit and save
                    """);

            var input = GetNotEmptyInput("Type in a letter here:");

            switch (input.ToLower())
            {
                case "v":
                    ViewAllCars(_carsRepository);
                    break;
                case "c":
                    ViewCarsByListPrice(_carsProvider);
                    break;
                case "g":
                    _dataGenerator.GenerateAndAddSampleCars();
                    break;
                case "r":
                    RemoveEntity(_carsRepository);
                    break;
                case "s":
                    FindCarByID(_carsRepository);
                    break;
                case "q":
                    isRunning = CloseApp(_carsRepository);
                    break;
                default:
                    WriteColorLine("Invalid input", ConsoleColor.Red);

                    continue;
            }
        }
    }
    

    public void WriteColorLine(string line, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(line);
        Console.ResetColor();
    }


    public string GetNotEmptyInput(string quest)
    {
        Console.WriteLine(quest);
        var input = Console.ReadLine();

        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("The input can not be empty");
            input = Console.ReadLine();
        }
        return input;
    }

    private void RemoveEntity(IRepository<Car> repository)
    {
        var itemToRemove = FindCarByID(repository);
        if (itemToRemove is not null)
        {
            repository?.Remove(itemToRemove);
        }
    }

    private Car? FindCarByID(IRepository<Car> repository)
    {
        while (true)
        {

            var input = GetNotEmptyInput("Please input (numbers only) ID:");
            int parsedId;

            if (!int.TryParse(input, out parsedId))
            {
                WriteColorLine("Please input only interger number", ConsoleColor.Red);
            }
            else
            {
                var car = repository.GetById(parsedId);
                if (car is not null)
                {
                    WriteColorLine(car.ToString(), ConsoleColor.Yellow);
                    return car;
                }
                else
                {
                    WriteColorLine($"There is no car with ID = {input}", ConsoleColor.DarkRed);
                    return null;
                }
            }
        }
    }
    private void ViewAllCars(IRepository<Car> repository)
    {
        var cars = repository.GetAll().ToList();
        if (cars.Count() > 0)
        {
            foreach (var car in cars)
            {
                WriteColorLine(car.ToString(), ConsoleColor.Yellow);
            }
        }
        else
        {
            WriteColorLine("There is no data to print.", ConsoleColor.Red);
        }
    }

    private void ViewCarsByListPrice(ICarsProvider cars)
    {
        var cheapCars = cars.OrderByPrice();
        if (cheapCars.Count() > 0)
        {
            foreach (var car in cheapCars)
            {
                WriteColorLine(car.ToString(), ConsoleColor.Yellow);
            }
        }
        else
        {
            WriteColorLine("There is no data to print.", ConsoleColor.Red);
        }
    }

    private bool CloseApp(IRepository<Car> carsRepository)
    {
        while (true)
        {
            var choice = GetNotEmptyInput("Do you want to save changes on exit?\nType y if yes\t\tType n if no").ToUpper();
            if (choice == "Y")
            {
                carsRepository.Save();
                WriteColorLine("Changes successfully saved.", ConsoleColor.Green);
                return false;
            }
            else if (choice == "N")
            {
                return false;
            }
            else
            {
                WriteColorLine("Invalid input. Please choose yes or no:", ConsoleColor.Red);
            }
        }
    }
}
