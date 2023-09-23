using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoApp.Entities;
using MotoApp.Repositories;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotoApp.Services;

public class DataGenerator : IDataGenerator
{
    private readonly IRepository<Car> _carsRepository;
    
    public DataGenerator(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public void AddCars()
    {
        _carsRepository.Read();
    }


    public void GenerateAndAddSampleCars()
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
            new Car { Id = 6, Name = "BMW", Color = "Silver", StandardCost = 11000.00m, ListPrice = 17000.00m, Type = "Coupe" },
            new Car { Id = 7, Name = "Toyota", Color = "Gray", StandardCost = 10000.00m, ListPrice = 16000.00m, Type = "Sedan" },
            new Car { Id = 8, Name = "Lexus", Color = "Silver", StandardCost = 9600.00m, ListPrice = 14000.00m, Type = "SUV" },
            new Car { Id = 9, Name = "Buick", Color = "Green", StandardCost = 9500.00m, ListPrice = 14000.00m, Type = "SUV" }
        };
    }
}
