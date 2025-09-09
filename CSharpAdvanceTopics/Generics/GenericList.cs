using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceTopics.Generics
{
    public class GenericList<T>
    {
        // Internal storage for items
        private readonly List<T> _items = new();

        // Add item to the list
        public void Add(T item)
        {
            _items.Add(item);
        }

        // Count property to get the number of items
        public int Count => _items.Count;

        // Indexer to access items by index
        public T this[int index] => _items[index];

        // Optional: Remove item
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        // Optional: Clear the list
        public void Clear()
        {
            _items.Clear();
        }
    }
}
