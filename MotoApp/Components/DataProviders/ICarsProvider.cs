using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders;

public interface ICarsProvider
{
    decimal GetMinimumPriceOfAllCars();

    List<string> GetUniqueCarColors();

    List<Car> GetIDsNamesTypes();
    string GetIDsNamesTotalSalesAnonymously();
    List<Car> OrderByPrice();
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
    List<Car> TakeCars(int howMany);
    List<Car> TakeCars(Range range);
    List<Car> TakeCarsWhileNameStartsWith(string prefix);
    List<Car> SkipCars(int howMany);
    List<Car> SkipCarsWhileNameStartsWith(string prefix);
    List<Car> DistinctByColor();
    List<Car[]> ChunkCars(int size);
}
