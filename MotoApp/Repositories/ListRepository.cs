namespace MotoApp.Repositories
{
    using MotoApp.Entities;
    using System.Text.Json;

    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly List<T> _items = new();
        private int recentId = 1;
        private readonly string path = $"{typeof(T).Name}_save.json";

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public void Add(T item)
        {
            if (_items.Count == 0)
            {
                item.Id = recentId;
                recentId++;
            }
            else if (_items.Count > 0)
            {
                recentId = _items[_items.Count - 1].Id;
                item.Id = ++recentId;
            }

            _items.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public T? GetById(int id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }

        public IEnumerable<T> Read()
        {
            if (File.Exists(path))
            {
                var serializedItems = File.ReadAllText(path);
                var deserializedItems = JsonSerializer.Deserialize<IEnumerable<T>>(serializedItems);

                if (deserializedItems != null)
                {
                    foreach (var item in deserializedItems)
                    {
                        _items.Add(item);
                    }
                }
            }
            return _items;
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            File.Delete(path);
            var objectsToSave = JsonSerializer.Serialize<IEnumerable<T>>(_items);
            File.WriteAllText(path, objectsToSave);
        }
    }
}
