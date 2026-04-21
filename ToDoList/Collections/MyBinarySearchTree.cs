using System.ComponentModel.Design.Serialization;

public class MyBinarySearchTree<T> : IMyCollection<T> where T : iDatabase, IComparable<T>
{
    public TreeNode<T>? Root { get; set; }
    public int Count => throw new NotImplementedException();

    public bool Dirty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Add(T value) => Add(value, Root);
    public void AddIterative(T value)
    {
        if (Root == null)
        {
            Root = new TreeNode<T>(value);
            return;
        }

        var current = Root;

        while (true)
        {
            if (value.CompareTo(current.Value) == 0)
            {
                // Value already exists, do not add duplicates
                return;
            }
            else if (value.CompareTo(current.Value) < 0)
            {
                // Go left
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(value, current);
                    return;
                }
                current = current.Left;
            }
            else
            {
                // Go right
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value, current);
                    return;
                }
                current = current.Right;
            }
        }
    }

    public void Add(T value, TreeNode<T> node)
    {
        // Root is null
        if (Root == null)
        {
            Root = new TreeNode<T>(value);
            return;
        }

        if (node.Value.CompareTo(value) > 0)
        {
            if(node.Left == null)
            {
                node.Left = new TreeNode<T>(value, node);
                return;
            }
            Add(value, node.Left);
        }

        else if(node.Value.CompareTo(value) < 0){
            if(node.Right == null){
               node.Right = new TreeNode<T>(value, node);
               return;
            }
            
            Add(value, node.Right);
        } 

        else return;
    }

    public void Clear()
    {
        Root = null;
    }

    public IMyCollection<T> Filter(Func<T, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public T FindBy<K>(K key, Func<T, K, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IMyIterator<T> GetIterator()
    {
        throw new NotImplementedException();
    }

    public R Reduce<R>(Func<R, T, R> accumulator, R initial)
    {
        throw new NotImplementedException();
    }

    public void Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void Sort(Comparison<T> comparison)
    {
        throw new NotImplementedException();
    }

    public void Update(T task)
    {
        throw new NotImplementedException();
    }
}