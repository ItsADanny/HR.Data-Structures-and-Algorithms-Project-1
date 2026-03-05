public class MyIterator<T> : IMyIterator<T>
{
    //https://medium.com/@lakstutor/iterator-pattern-in-c-from-basics-to-advanced-c232cc4584e
    private T[] _items;
    private int _current = 0;
    public MyIterator(T[] items)
    {
        _items = items;
    }

    public bool HasNext()
    {
        return _current < _items.Length && _items[_current] != null;
    }

    public T Next()
    {
        _current++;

        if (!HasNext())
            throw new InvalidOperationException("No more elements in the collection.");

        return _items[_current];
    }

    public void Reset()
    {
        _items = default;
        _current = 0;
    }
}