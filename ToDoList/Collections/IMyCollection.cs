public interface IMyCollection<T>
{
    int Count { get; } 
    bool Dirty { get; set;}

    void Add(T item); //Done
    // void Update(T item);
    void Remove(T item); //Done

    void Update(T task);

    T FindBy(Func<T, bool> predicate); //Done
    IMyCollection<T> Filter(Func<T, bool> predicate); //Done
    void Sort(Comparison<T> comparison); //Done
    void Clear();//Done
    R Reduce<R>(Func<R, T, R> accumulator, R initial); //Done
    IMyIterator<T> GetIterator();
    IEnumerator<T> GetEnumerator();
}
public interface IMyIterator<T>
{
    bool HasNext();
    T Next();
    void Reset();
}