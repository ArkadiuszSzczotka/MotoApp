namespace MotoApp.Entities
{
    public class BusinessPartner : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString() => $"ID {Id}, FirstName: {FirstName}";
    }
}
