using System.Text;

namespace MotoApp.Entities;

public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }

    public int? NameLength { get; set; }

    public decimal? TotalSales { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new (1024);

        stringBuilder.AppendLine($"{Name} ID: {Id}");
        stringBuilder.AppendLine($" Color: {Color}  Type: {(Type ?? "n/a")}");
        stringBuilder.AppendLine($" Cost: {StandardCost:c}    Price: {ListPrice:c}");
        if(NameLength.HasValue)
        {
            stringBuilder.AppendLine($" Name length:    {NameLength}");
        }
        if(TotalSales.HasValue)
        {
            stringBuilder.AppendLine($" Total sales:    {TotalSales}");
        }

        return stringBuilder.ToString();
    }

}
