public class SingleNode<T>
{
    public T Value;
    public SingleNode<T> Next;

    public SingleNode(T value, SingleNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}