using MotoApp.Entities;
using MotoApp.Repositories;

namespace MotoApp.DataProviders;

public class CarsProviderBasic : ICarsProvider
{
    private readonly IRepository<Car> _carsRepository;

    public CarsProviderBasic(IRepository<Car> carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public List<Car> FilterCars(decimal minimumPrice)
    {
        var cars = _carsRepository.GetAll();
        var list = new List<Car>();

        foreach (var car in cars)
        {
            if (car.ListPrice > minimumPrice)
            {
                list.Add(car);
            }
        }

        return list;
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }

    public List<string> GetUniqueCarColors()
    {
        throw new NotImplementedException();
    }
}
