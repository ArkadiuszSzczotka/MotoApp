using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders.Extenions;

public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
    {
        return query.Where(c => c.Color == color);
    }
}
