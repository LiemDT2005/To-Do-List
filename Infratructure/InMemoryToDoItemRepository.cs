using Entities;
using UseCases;

namespace Infratructure
{
    public class InMemoryToDoItemRepository : ITodoItemRepository
    {
        private readonly List<TodoItem> _items;

        public InMemoryToDoItemRepository() {   
            _items = [];
        }

        public void Add(TodoItem item)
        {
            // Assign a new Id if not set
            if (item.Id == 0)
            {
                item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            }
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public TodoItem? GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<TodoItem> GetItems()
        {
            return _items;
        }

        public void Update(TodoItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existing != null)
            {
                existing.Text = item.Text;
                existing.IsCompleted = item.IsCompleted;
            }
        }
    }
}
