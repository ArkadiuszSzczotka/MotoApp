using MotoApp.Entities;

namespace MotoApp.DataProviders;

public interface ICarsProvider
{
    decimal GetMinimumPriceOfAllCars();

    List<string> GetUniqueCarColors();

    List<Car> GetIDsNamesTypes();
    string GetIDsNamesTotalSalesAnonymously();
    List<Car> OrderByNameAndThenByColor();

    List<Car> OrderByNameDescendingAndThenByColorDescending();

}
