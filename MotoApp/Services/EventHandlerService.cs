using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp.Services;

public class EventHandlerService : IEventHandlerService
{
    private readonly IRepository<Car> _carsRepository;
    private readonly IUserCommunication _userCommunication;

    public EventHandlerService(IRepository<Car> carsRepository, IUserCommunication userCommunication)
    {
        _carsRepository = carsRepository;
        _userCommunication = userCommunication;
    }

    public void SubscribeOnEvents()
    {
        _carsRepository.ItemAdded += OnCarsRepositoryItemAdded;
        _carsRepository.ItemRemoved += OnCarsRepositoryItemRemoved;
        _carsRepository.ItemAdded += OnItemAddedAudit;
        _carsRepository.ItemRemoved += OnItemRemovedAudit;
    }

    private void OnItemRemovedAudit(object? sender, Car car)
    {
        if (sender is not null)
        {
            using (var writer = File.AppendText(IRepository<IEntity>.auditFileName))
            {
                writer.WriteLine($"[{DateTime.UtcNow}]\tremoved:\n  [ID: {car.Id} \t{car.Name}]");
            }
        }
    }

    private void OnItemAddedAudit(object? sender, Car car)
    {
        if (sender is not null)
        {
            using (var writer = File.AppendText(IRepository<IEntity>.auditFileName))
            {
                writer.WriteLine($"[{DateTime.UtcNow}]\tadded:\n  [ID: {car.Id} \t{car.Name}]");
            }
        }
    }

    private void OnCarsRepositoryItemRemoved(object? sender, Car car)
    {
        if (sender is not null)
        {
            _userCommunication.WriteColorLine($"Car {car} removed from {sender.GetType().Name}", ConsoleColor.Magenta);
        }
    }

    private void OnCarsRepositoryItemAdded(object? sender, Car car)
    {
        if (sender is not null)
        {
            _userCommunication.WriteColorLine($"Car {car.Name} added from {sender.GetType().Name}", ConsoleColor.Yellow);
        }
    }


}
