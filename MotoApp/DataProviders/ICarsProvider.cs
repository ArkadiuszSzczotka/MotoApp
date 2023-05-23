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

    List<Car> WhereStartsWith(string prefix);
    List<Car> WhereStartsWithAndCostGreaterThan(string prefix, decimal cost);
    List<Car> WhereColorIs(string color);
////First and Single
    Car FirstByColor(string color);
    Car? FirstOrDefaultByColor(string color);
    Car FirstOrDefaultByColorWithDefault(string color);
    Car? SingleOrDefault(int id);
}
