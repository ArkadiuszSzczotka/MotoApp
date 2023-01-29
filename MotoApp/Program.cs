using MotoApp.Repositories;
using MotoApp.Entities;

var employeeRepository = new GenericRepository<Employee>();

employeeRepository.Add(new Employee { FirstName = "Arek" });
employeeRepository.Add(new Employee { FirstName = "Marek" });
employeeRepository.Add(new Employee { FirstName = "Jola" });

employeeRepository.Save();

var empRepoWithRemove = new GenericRepositoryWithRemove<Employee>();
empRepoWithRemove.Add(new Employee { FirstName = "Tomek" });
empRepoWithRemove.Add(new Employee { FirstName = "Adam" });