using MotoApp.DataProviders.Extenions;
using MotoApp.Entities;
using MotoApp.Repositories;
using System.Linq;
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

    public List<Car> WhereStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(c => c.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWithAndCostGreaterThan(string prefix, decimal cost)
    {
        var cars = _carRepository.GetAll();
        return cars.Where(c => c.Name.StartsWith(prefix) && c.StandardCost > cost).ToList();
    }

    public List<Car> WhereColorIs(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.ByColor(color).ToList();
    }

    public Car FirstByColor(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.First(c => c.Color == color);
    }

    public Car? FirstOrDefaultByColor(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.FirstOrDefault(c => c.Color == color);
    }

    public Car FirstOrDefaultByColorWithDefault(string color)
    {
        var cars = _carRepository.GetAll();
        return cars
            .FirstOrDefault(
                c => c.Color == color,
                new Car { Id = -1, Name = "NOT FOUND" });
    }

    public Car? SingleOrDefault(int id)
    {
        var cars = _carRepository.GetAll();
        return cars.SingleOrDefault(c => c.Id == id);
    }

    public List<Car> TakeCars(int howMany)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .Take(howMany)
            .ToList();
    }

    public List<Car> TakeCars(Range range)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .Take(range)
            .ToList();
    }

    public List<Car> TakeCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .TakeWhile(c => c.Name.StartsWith(prefix))          
            .ToList();            
    }

    public List<Car> SkipCars(int howMany)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .Skip(howMany)
            .ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        var cars = _carRepository.GetAll();
        return cars
            .OrderBy(c => c.Name)
            .SkipWhile(c => c.Name.StartsWith(prefix))
            .ToList();
    }

    public List<Car> DistinctByColor()
    {
        var cars = _carRepository.GetAll();
        return cars.DistinctBy(c => c.Color).ToList();
    }

    public List<Car[]> ChunkCars(int size)
    {
        var cars = _carRepository.GetAll();
        return cars.Chunk(size).ToList();
    }
}
