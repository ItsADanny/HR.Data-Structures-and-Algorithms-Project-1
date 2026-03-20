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
        Node current = _head;
        int index = 0;
        while (current != null)
        {
            if (current.Value.Equals(item))
                return index;

            current = current.Next;
            index++;
        }
        return -1;
    }

    public void Sort(Comparison<T> comparison)
    {
        _head = MergeSort(_head, comparison);
    }

    private Node MergeSort(Node head, Comparison<T> comparison)
    {
        if (head == null || head.Next == null)
            return head;

        Node middle = GetMiddle(head);
        Node nextOfMiddle = middle.Next;
        middle.Next = null;

        Node left = MergeSort(head, comparison);
        Node right = MergeSort(nextOfMiddle, comparison);

        return Merge(left, right, comparison);
    }

    private Node GetMiddle(Node head)
    {
        if (head == null) return head;

        Node slow = head, fast = head.Next;
        while (fast != null)
        {
            fast = fast.Next;
            if (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
        }
        return slow;
    }

    private Node Merge(Node left, Node right, Comparison<T> comparison)
    {
        if (left == null) return right;
        if (right == null) return left;

        Node result;
        if (comparison(left.Value, right.Value) <= 0)
        {
            result = left;
            result.Next = Merge(left.Next, right, comparison);
        }
        else
        {
            result = right;
            result.Next = Merge(left, right.Next, comparison);
        }
        return result;
    }

    public void Clear()
    {
        _head = null;
        _count = 0;
    }

    public R Reduce<R>(Func<R, T, R> accumulator, R initial)
    {
        R result = initial;
        Node current = _head;
        for (int i = 0; i < _count; i++)
        {
            result = accumulator(result, current.Value);
            current = current.Next;
        }
        return result;
    }

    public IMyIterator<T> GetIterator()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
}