public class MyLinkedList<T> : IMyCollection<T>
{
    private Node _head;
    private int _count;

    public int Count => _count;

    public bool Dirty { get; set; }

    private class Node
    {
        public T Value;
        public Node Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    public void Remove(T item)
    {
        if (_head == null) return;

        if (_head.Value.Equals(item))
        {
            _head = _head.Next;
            _count--;
            return;
        }

        Node current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(item))
            {
                current.Next = current.Next.Next;
                _count--;
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            _head = _head.Next;
            _count--;
            return;
        }

        Node current = _head;
        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }
        current.Next = current.Next.Next;
        _count--;
    }

    public T FindBy<K>(K key, Func<T, K, bool> predicate)
    {
        Node current = _head;
        while (current != null)
        {
            if (predicate(current.Value, key))
                return current.Value;

            current = current.Next;
        }
        return default(T);
    }

    public IMyCollection<T> Filter(Func<T, bool> predicate)
    {
        MyLinkedList<T> result = new MyLinkedList<T>();
        Node current = _head;
        while (current != null)
        {
            if (predicate(current.Value))
                result.Add(current.Value);

            current = current.Next;
        }
        return result;
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Sort(Comparison<T> comparison)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public R Reduce<R>(Func<R, T, R> accumulator, R initial)
    {
        throw new NotImplementedException();
    }

    public IMyIterator<T> GetIterator()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }
}