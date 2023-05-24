using MotoApp;
using MotoApp.DataProviders;
using MotoApp.DataProviders.Extenions;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;
using System.Text;

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

        _employeesRepository.AddBatchThenSave(employees);
        
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
        var carsByNameAndThenByColor = _carsProvider.OrderByNameAndThenByColor();
        carsByNameAndThenByColor.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Ordered by name and color in descending order:");
        var carsOrderedDescending = _carsProvider.OrderByNameDescendingAndThenByColorDescending();
        carsOrderedDescending.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Where name starts with M:");
        var carsStartsWith = _carsProvider.WhereStartsWith("M");
        carsStartsWith.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Cars wheres name starts with F and cost is greater than 9500:");
        var carsStartsWithAndCost = _carsProvider.WhereStartsWithAndCostGreaterThan("F", 9500);
        carsStartsWithAndCost.ForEach(car => Console.WriteLine(car));

        Console.WriteLine("Cars filtered by color using extension method:");
        var carsByColor = _carsProvider.WhereColorIs("Green");
        carsByColor.ForEach(car => Console.WriteLine(car));

        
        var firstCarByColor = _carsProvider.FirstByColor("Red");
        StringBuilder sb = new(2048);
        sb.AppendLine($"Product ID: {firstCarByColor.Id}");
        sb.AppendLine($"Product name: {firstCarByColor.Name}");
        sb.AppendLine($"Color: {firstCarByColor.Color}");
        Console.WriteLine($"First car by color (without validation) is:\n{sb}");

        var firstOrDefaultCar = _carsProvider.FirstOrDefaultByColor("Silver");
        if( firstOrDefaultCar != null )
        {
            StringBuilder sbd = new();
            sbd.AppendLine($"Product ID: {firstOrDefaultCar.Id}");
            sbd.AppendLine($"Product name: {firstOrDefaultCar.Name}");
            sbd.AppendLine($"Color: {firstOrDefaultCar.Color}");
            Console.WriteLine($"First car by color is:\n{sbd}");
        } else
        {
            Console.WriteLine("There is no such car color available");
        }

        var firstOrDefaultCarNoNull = _carsProvider.FirstOrDefaultByColorWithDefault("Black");
        StringBuilder sbdd = new();
        sbdd.AppendLine($"Product ID: {firstOrDefaultCarNoNull.Id}");
        sbdd.AppendLine($"Product name: {firstOrDefaultCarNoNull.Name}");
        sbdd.AppendLine($"Color: {firstOrDefaultCarNoNull.Color}");
        Console.WriteLine($"First car by color is:\n{sbdd}");

        var singleCar = _carsProvider.SingleOrDefault(9);
        if (singleCar != null)
        {
            StringBuilder sbs = new(2048);
            sbs.AppendLine($"Product ID: {singleCar.Id}");
            sbs.AppendLine($"Product name: {singleCar.Name}");
            sbs.AppendLine($"List Price: {singleCar.ListPrice}");
            Console.WriteLine($"Single car by ID is:\n{sbs}");
        }
        else
        {
            Console.WriteLine("There is no such car");
        }

        var fourCars = _carsProvider.TakeCars(4);
        Console.WriteLine("Four cars ordered by name:");
        fourCars.ForEach(car => Console.WriteLine(car));

        var rangeOfCars = _carsProvider.TakeCars(0..1);
        Console.WriteLine("Cars from 0 to 1 ordered by name:");
        rangeOfCars.ForEach(car => Console.WriteLine(car));

        const string letters = "F";
        var takenWithPrefixCars = _carsProvider.TakeCarsWhileNameStartsWith(letters);
        Console.WriteLine($"Cars which name starts with {letters}:");
        takenWithPrefixCars.ForEach(car => Console.WriteLine(car));

    }

    public static List<Car> GenerateCars()
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
}
