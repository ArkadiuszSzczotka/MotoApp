using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployees(employeeRepository);
AddManagers(employeeRepository);
WriteToConsole(employeeRepository);

static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Arek" });
    employeeRepository.Add(new Employee { FirstName = "Zuzia" });
    employeeRepository.Add(new Employee { FirstName = "Basia" });
    employeeRepository.Save();
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