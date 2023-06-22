using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp;

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
    }

    public void OnCarsRepositoryItemRemoved(object? sender, Car car)
    {
        if (sender is not null)
        {
            _userCommunication.WriteColorLine($"Car {car} removed from {sender.GetType().Name}", ConsoleColor.Magenta);
        }
    }

    public void OnCarsRepositoryItemAdded(object? sender, Car car)
    {
        if (sender is not null)
        {
            _userCommunication.WriteColorLine($"Car {car.Name} added from {sender.GetType().Name}", ConsoleColor.Yellow);
        }
    }


}
