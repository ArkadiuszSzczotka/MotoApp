using MotoApp;
using MotoApp.Services;

public class App : IApp
{
    private readonly IUserCommunication _userCommunication;
    private readonly IEventHandlerService _eventHandlerService;
    private readonly IDataGenerator _dataGenerator;

    public App(IUserCommunication userCommunication, IEventHandlerService eventHandlerService, IDataGenerator dataGenerator)        
    {
        _userCommunication = userCommunication;
        _eventHandlerService = eventHandlerService;
        _dataGenerator = dataGenerator;
        
    }
    public void Run()
    {        
        _eventHandlerService.SubscribeOnEvents();        
        _dataGenerator.AddCars();
        _userCommunication.ChooseAction();


        //Console.WriteLine($"Price of the cheapest car is: {_carsProvider.GetMinimumPriceOfAllCars():C}");

        //Console.WriteLine("The cars are available in the following colors:");
        //var availableCarsColors = _carsProvider.GetUniqueCarColors();
        //availableCarsColors.ForEach(car => Console.WriteLine(car));

        //Console.WriteLine("Show not everything about cars:");
        //foreach (var item in _carsProvider.GetIDsNamesTypes())
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine("Using anonymous class show not everything about cars:");
        //Console.WriteLine(_carsProvider.GetIDsNamesTotalSalesAnonymously());

        //Console.WriteLine("Ordered by name and color:");
        //var carsByNameAndThenByColor = _carsProvider.OrderByNameAndThenByColor();
        //carsByNameAndThenByColor.ForEach(car => Console.WriteLine(car));

        //Console.WriteLine("Ordered by name and color in descending order:");
        //var carsOrderedDescending = _carsProvider.OrderByNameDescendingAndThenByColorDescending();
        //carsOrderedDescending.ForEach(car => Console.WriteLine(car));

        //Console.WriteLine("Where name starts with M:");
        //var carsStartsWith = _carsProvider.WhereStartsWith("M");
        //carsStartsWith.ForEach(car => Console.WriteLine(car));

        //Console.WriteLine("Cars wheres name starts with F and cost is greater than 9500:");
        //var carsStartsWithAndCost = _carsProvider.WhereStartsWithAndCostGreaterThan("F", 9500);
        //carsStartsWithAndCost.ForEach(car => Console.WriteLine(car));

        //Console.WriteLine("Cars filtered by color using extension method:");
        //var carsByColor = _carsProvider.WhereColorIs("Green");
        //carsByColor.ForEach(car => Console.WriteLine(car));


        //var firstCarByColor = _carsProvider.FirstByColor("Red");
        //StringBuilder sb = new(2048);
        //sb.AppendLine($"Product ID: {firstCarByColor.Id}");
        //sb.AppendLine($"Product name: {firstCarByColor.Name}");
        //sb.AppendLine($"Color: {firstCarByColor.Color}");
        //Console.WriteLine($"First car by color (without validation) is:\n{sb}");

        //var firstOrDefaultCar = _carsProvider.FirstOrDefaultByColor("Silver");
        //if (firstOrDefaultCar != null)
        //{
        //    StringBuilder sbd = new();
        //    sbd.AppendLine($"Product ID: {firstOrDefaultCar.Id}");
        //    sbd.AppendLine($"Product name: {firstOrDefaultCar.Name}");
        //    sbd.AppendLine($"Color: {firstOrDefaultCar.Color}");
        //    Console.WriteLine($"First car by color is:\n{sbd}");
        //}
        //else
        //{
        //    Console.WriteLine("There is no such car color available");
        //}

        //var firstOrDefaultCarNoNull = _carsProvider.FirstOrDefaultByColorWithDefault("Black");
        //StringBuilder sbdd = new();
        //sbdd.AppendLine($"Product ID: {firstOrDefaultCarNoNull.Id}");
        //sbdd.AppendLine($"Product name: {firstOrDefaultCarNoNull.Name}");
        //sbdd.AppendLine($"Color: {firstOrDefaultCarNoNull.Color}");
        //Console.WriteLine($"First car by color is:\n{sbdd}");

        //var singleCar = _carsProvider.SingleOrDefault(9);
        //if (singleCar != null)
        //{
        //    StringBuilder sbs = new(2048);
        //    sbs.AppendLine($"Product ID: {singleCar.Id}");
        //    sbs.AppendLine($"Product name: {singleCar.Name}");
        //    sbs.AppendLine($"List Price: {singleCar.ListPrice}");
        //    Console.WriteLine($"Single car by ID is:\n{singleCar}");
        //}
        //else
        //{
        //    Console.WriteLine("There is no such car");
        //}

        //var fourCars = _carsProvider.TakeCars(4);
        //Console.WriteLine("Four cars ordered by name:");
        //fourCars.ForEach(car => Console.WriteLine(car));

        //var rangeOfCars = _carsProvider.TakeCars(0..1);
        //Console.WriteLine("Cars from 0 to 1 ordered by name:");
        //rangeOfCars.ForEach(car => Console.WriteLine(car));

        //const string letters = "B";
        //var takenWithPrefixCars = _carsProvider.TakeCarsWhileNameStartsWith(letters);
        //Console.WriteLine($"Cars which name starts with {letters}:");
        //takenWithPrefixCars.ForEach(car => Console.WriteLine(car));

        //var carsWithoutSkipped = _carsProvider.SkipCars(5);
        //Console.WriteLine("Cars without skiped five of them:");
        //carsWithoutSkipped.ForEach(car => Console.WriteLine(car));

        //var carsWithoutSkippedPrefix = _carsProvider.SkipCarsWhileNameStartsWith(letters);
        //Console.WriteLine($"Cars which name does not start with {letters}:");
        //carsWithoutSkippedPrefix.ForEach(car => Console.WriteLine(car));

        //var carsDistinctedColors = _carsProvider.DistinctByColor();
        //Console.WriteLine("Cars are in colors:");
        //carsDistinctedColors.ForEach(car => Console.WriteLine(car));

        //const int size = 3;
        //var chunkedCars = _carsProvider.ChunkCars(size);
        //for (int i = 0; i < chunkedCars.Count; i++)
        //{
        //    Console.WriteLine($"Pack {i}");
        //    foreach (var car in chunkedCars[i])
        //    {
        //        Console.WriteLine(car.Name);
        //    }
        //}

    }

    
}
