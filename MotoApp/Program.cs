using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;
using MotoApp.Repositories.Extensions;
using MotoApp.Entities.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
employeeRepository.ItemAdded += RepositoryOnItemAdded;

void RepositoryOnItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added - {e.FirstName} from {sender?.GetType().Name}");
}

AddManagers(employeeRepository);
AddEmployees(employeeRepository);
WriteToConsole(employeeRepository);

static void EmployeeAdded(Employee item)
{
    Console.WriteLine($"{item.FirstName} added");
}
static void AddEmployees(IRepository<Employee> employeeRepository)
{
    var employees = new[]
    {
    new Employee{ FirstName = "Tom"},
    new Employee{ FirstName = "Arek"},
    new Employee{ FirstName = "Zuzanna"}
    };

    employeeRepository.AddBatch(employees);
}



static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Grzegorz" });
    managerRepository.Add(new Manager { FirstName = "Mask" });
    managerRepository.Save();
}

static void WriteToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach(var item in items)
    {
        Console.WriteLine(item);
    }    
}