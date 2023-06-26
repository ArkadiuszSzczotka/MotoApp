namespace MotoApp.Repositories
{
    using MotoApp.Entities;
    using System.Text.Json;

    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly List<T> _items = new();
        private readonly string path = $"{typeof(T).Name}_save.json";

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public T? GetById(int id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            var objectsToSave = JsonSerializer.Serialize<IEnumerable<T>>(_items);
            File.WriteAllText(path, objectsToSave);
        }
    }
}
