using MotoApp.Entities;
using MotoApp.Repositories;
using System.Runtime.CompilerServices;
using System.Text;

namespace MotoApp.DataProviders;

public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carRepository;
    public CarsProvider(IRepository<Car> carsProvider)
    {
        _carRepository = carsProvider;
    }
    public string GetIDsNamesTotalSalesAnonymously()
    {
        var cars = _carRepository.GetAll();
        var idsNamesTotalSales = cars.Select(
            c => new
            {
                c.Id,
                NameOfProduct = c.Name,
                TotalSalesOfProduct = c.TotalSales
            }).ToList();

        StringBuilder sb = new(2048);

        foreach(var car in idsNamesTotalSales)
        {
            sb.AppendLine($"Product ID: {car.Id}");
            sb.AppendLine($"Product name: {car.NameOfProduct}");
            sb.AppendLine($"Total sales of product: {car.TotalSalesOfProduct}");
        }

        return sb.ToString();
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        var cars = _carRepository.GetAll();
        return cars.Select(c => c.ListPrice).Min();
    }

    public List<Car> GetIDsNamesTypes()
    {
        var cars = _carRepository.GetAll();

        var idsNamesTypes = cars.Select(car => new Car
        {
            Id = car.Id,
            Name = car.Name,
            Type = car.Type
        }).ToList();

        return idsNamesTypes;
    }

    public List<string> GetUniqueCarColors()
    {
        var cars = _carRepository.GetAll();
        var carColors = cars.Select(c => c.Color).Distinct().ToList();
        return carColors;
    }

    public List<Car> OrderByNameAndThenByColor()
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .ThenBy(c => c.Color)
            .ToList();
    }
    public List<Car> OrderByNameDescendingAndThenByColorDescending()
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderByDescending(c => c.Name)
            .ThenByDescending(c => c.Color)
            .ToList();
    }
}
