using System.Dynamic;

public class MyHashmap<TKey, TValue>
{
    public readonly int Capacity;
    private readonly MyLinkedList<KeyValuePair<TKey, TValue>>[] _buckets;

    public MyHashmap(int capacity = 10)
    {
        Capacity = capacity;
        _buckets = new MyLinkedList<KeyValuePair<TKey, TValue>>[capacity];
    }

    public int GetIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode() % Capacity);
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetIndex(key);

        _buckets[index] ??= new MyLinkedList<KeyValuePair<TKey, TValue>>();
        
        foreach (var kvp in _buckets[index])
        {
            if (kvp.Key.Equals(key))
            {
                throw new ArgumentException($"Key '{key}' already exists in the hashmap.");
            }
        }
        _buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public TValue Get(TKey key)
    {
        int index = GetIndex(key);
        if (_buckets[index] == null)
        {
            throw new KeyNotFoundException($"Key '{key}' not found in the hashmap.");
        }        
        foreach (var kvp in _buckets[index])
        {
            if (kvp.Key.Equals(key))
            {
                return kvp.Value;
            }
        }
        throw new KeyNotFoundException();
    }
}
