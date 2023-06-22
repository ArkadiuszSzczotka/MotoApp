using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.DataProviders;
using MotoApp.Entities;
using MotoApp.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app!.Run();



//using MotoApp.Repositories;
//using MotoApp.Entities;
//using MotoApp.Data;
//using MotoApp.Repositories.Extensions;
//using MotoApp.Entities.Extensions;
//using System.Text.Json;

//Console.WriteLine("App for attendance list.\n");
//var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//employeeRepository.ItemAdded += RepositoryOnItemAdded;
//employeeRepository.ItemRemoved += RepositoryOnItemRemoved;

//bool appIsRunning = true;

//while (appIsRunning)
//{
//    Console.WriteLine("Please choose what to do:\nA - to add Employees\nM - to add Managers\nD - to delete by ID\nS - to show list\n q - to quit console");
//    var input = Console.ReadLine()?.ToLower();

//    switch (input)
//    {
//        case "a":
//            AddEmployees(employeeRepository);
//            break;

//        case "m":
//            AddManagers(employeeRepository);
//            break;

//        case "d":
//            var id = ReadId();
//            RemoveEntity(employeeRepository, id);
//            break;

//        case "s":
//            WriteToConsole(employeeRepository);
//            break;

//        case "q":
//            appIsRunning = false;
//            break;

//        default:
//            Console.Clear();
//            Console.Write("Inputed key is not valid\n");
//            break;
//    }
//}
//void RepositoryOnItemRemoved(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee removed - {e.FirstName} from {sender?.GetType().Name}");
//}

//void RepositoryOnItemAdded(object? sender, Employee e)
//{
//    Console.WriteLine($"Employee added - {e.FirstName} from {sender?.GetType().Name}");
//}

//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item.FirstName} added");
//}
//static void AddEmployees(IRepository<Employee> employeeRepository)
//{
//    var employees = new[]
//    {
//    new Employee{ FirstName = "Tom"},
//    new Employee{ FirstName = "Arek"},
//    new Employee{ FirstName = "Zuzanna"}
//    };

//    employeeRepository.AddBatch(employees);
//}

//static void AddManagers(IWriteRepository<Manager> managerRepository)
//{
//    managerRepository.Add(new Manager { FirstName = "Grzegorz" });
//    managerRepository.Add(new Manager { FirstName = "Mask" });
//    managerRepository.Save();
//}

//static void WriteToConsole(IReadRepository<IEntity> repository)

//{
//    var items = repository.GetAll();
//    foreach(var item in items)
//    {
//        Console.WriteLine(item);
//    }    
//}

//static void RemoveEntity(SqlRepository<Employee> repository, int id)
//{
//    var itemToRemove = repository?.GetById(id);
//    if (itemToRemove is not null)
//    {
//        var reader = JsonSerializer.Serialize(itemToRemove);
//        File.WriteAllText($@"C:\json\{nameof(itemToRemove)}.json", reader);
//        repository?.Remove(itemToRemove);
//        repository?.Save();
//    }
//    else
//    {
//        Console.WriteLine("There is no item to remove");
//    }
//}

//static int ReadId()
//{
//    Console.Clear();
//    Console.WriteLine("Please input numeric ID:");
//    var input = Console.ReadLine();

//    if (int.TryParse(input, out int id))
//    {
//        return id;
//    }
//    else
//    {
//        Console.Clear();
//        Console.WriteLine("Invalid input! 0 id returned");
//        return 0;
//    }
//}