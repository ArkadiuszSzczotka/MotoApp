using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
        public const string auditFileName = "auditedEntries.txt";

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
    }
}
