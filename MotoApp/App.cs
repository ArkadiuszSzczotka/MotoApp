using MotoApp;
using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

public class App : IApp
{
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(
        IRepository<Employee> employeesRepository,
        IRepository<Car> carsRepository,
        ICarsProvider carsProvider)
    {
        _employeesRepository = employeesRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }
    public void Run()
    {
        Console.WriteLine("Here you are in Run method.");

        var employees = new[]
        {
            new Employee{ FirstName = "Tom"},
            new Employee{ FirstName = "Arek"},
            new Employee{ FirstName = "Zuzanna"}
        };

        _employeesRepository.AddBatch(employees);
        _employeesRepository.Save();

        var items = _employeesRepository.GetAll();

        foreach (var item in items)
        {
            Console.WriteLine(item);
        }


        var cars = GenerateCars();

        foreach (var car in cars)
        {
            _carsRepository.Add(car);
        }

        Console.WriteLine($"Price of the cheapest car is: {_carsProvider.GetMinimumPriceOfAllCars():C}");

        Console.WriteLine("The cars are available in the following colors:");
        var availableCarsColors = _carsProvider.GetUniqueCarColors();
        availableCarsColors.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Show not everything about cars:");
        foreach (var item in _carsProvider.GetIDsNamesTypes())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Using anonymous class show not everything about cars:");
        Console.WriteLine(_carsProvider.GetIDsNamesTotalSalesAnonymously());

        Console.WriteLine("Ordered by name and color:");
        var orderedCarsByNameAndThenByColor = _carsProvider.OrderByNameAndThenByColor();
        orderedCarsByNameAndThenByColor.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Ordered by name and color in descending order:");
        var orderedCarsByNameDescendingAndThenByColorDescending = _carsProvider.OrderByNameDescendingAndThenByColorDescending();
        orderedCarsByNameDescendingAndThenByColorDescending.ForEach(car => Console.WriteLine(car));
    }

    public static List<Car> GenerateCars()
    {
        return new List<Car>()
            {
                new Car { Id = 1, Name = "Car 1", Color = "Red", StandardCost = 10000.00m, ListPrice = 15000.00m, Type = "Sedan" },
                new Car { Id = 2, Name = "Car 2", Color = "Blue", StandardCost = 12000.00m, ListPrice = 18000.00m, Type = "Convertible" },
                new Car { Id = 3, Name = "Car 3", Color = "Green", StandardCost = 8000.00m, ListPrice = 13000.00m, Type = "SUV" },
                new Car { Id = 4, Name = "Car 4", Color = "Yellow", StandardCost = 15000.00m, ListPrice = 20000.00m, Type = "Sports Car" },
                new Car { Id = 5, Name = "Car 5", Color = "Black", StandardCost = 9000.00m, ListPrice = 14000.00m, Type = "Hatchback" },
                new Car { Id = 6, Name = "Car 6", Color = "White", StandardCost = 11000.00m, ListPrice = 17000.00m, Type = "Coupe" },
                new Car { Id = 7, Name = "Car 7", Color = "Gray", StandardCost = 10000.00m, ListPrice = 16000.00m, Type = "Sedan" },
                new Car { Id = 8, Name = "Car 8", Color = "Silver", StandardCost = 9500.00m, ListPrice = 14000.00m, Type = "SUV" },
                new Car { Id = 9, Name = "Car 8", Color = "Green", StandardCost = 9500.00m, ListPrice = 14000.00m, Type = "SUV" }
            };
    }
}
