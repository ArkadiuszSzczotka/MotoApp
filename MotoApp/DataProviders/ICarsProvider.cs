using MotoApp.Entities;

namespace MotoApp.DataProviders;

public interface ICarsProvider
{
    List<Car> FilterCars(decimal minimumPrice);

    List<string> GetUniqueCarColors();

    decimal GetMinimumPriceOfAllCars();
}
