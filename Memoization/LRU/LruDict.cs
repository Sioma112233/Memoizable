using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Memoization
{
    public class LruDict<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int _cap;
        private MyLinkedList<(TKey key, TValue value)> _list;
        private IDictionary<TKey, Node<(TKey key, TValue value)>> _dict;

        public LruDict(int capacity, IDictionary<TKey, Node<(TKey, TValue)>> dict)
        {
            _cap = capacity;
            _dict = dict;
            _list = new MyLinkedList<(TKey, TValue)>();
        }

        public LruDict(int capacity) : this(capacity, new Dictionary<TKey, Node<(TKey, TValue)>>(capacity))
        {
        }

        public int Count => _dict.Count;
        public bool ContainsKey(TKey key) => _dict.ContainsKey(key);
        
        public void Add(TKey key, TValue value)
        {
            if (_dict.TryGetValue(key, out var node)) {
                node.data.value = value;

                // reloacte node to front
                _list.Remove(node);
                _list.AddFirst(node);

                return;
            }

            // cache is full
            if (_list.Size == _cap) {
                var lru = _list.Tail;
                _list.Remove(lru);
                _dict.Remove(lru.data.key);
            }

            node = _list.AddFirst((key, value));
            _dict[key] = node;
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            if (!_dict.TryGetValue(key, out var node))
                return false;
            
            _list.Remove(node);
            _dict.Remove(node.data.key);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!_dict.TryGetValue(key, out var node)) {
                value = default;
                return false;
            }

            _list.Remove(node);
            _list.AddFirst(node);

            value = node.data.value;
            return true;
        }

        public void Clear()
        {
            _dict.Clear();
            _list.Clear();
        }
        
        public TValue this[TKey key]
        {
            get {
                if (!TryGetValue(key, out var value))
                    throw new KeyNotFoundException();

                return value;
            }
            set => Add(key, value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _list
                .Select(node => new KeyValuePair<TKey, TValue>(node.data.key, node.data.value))
                .GetEnumerator();
        }

    #region More IDictionary implementations
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!Contains(item)) 
                return false;
            
            Remove(item.Key);
            return true;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dict.TryGetValue(item.Key, out var node) && item.Value.Equals(node.data.value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (var node in _list) {
                array[arrayIndex++] = new KeyValuePair<TKey, TValue>(node.data.key, node.data.value);
            }
        }
        
        public ICollection<TKey> Keys => _dict.Keys;
        public ICollection<TValue> Values => _dict.Values.Select(v => v.data.value).ToList();

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool IsReadOnly => false;
    #endregion
    }
}