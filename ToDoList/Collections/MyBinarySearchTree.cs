using System.ComponentModel.Design.Serialization;

public class MyBinarySearchTree<T> : IMyCollection<T> where T : iDatabase, IComparable<T>
{
    public TreeNode<T>? Root { get; set; }
    public int Count => throw new NotImplementedException();

    // do not have to implement this property, as the tree is always sorted and we can easily find the position of an element in the tree.
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
        var result = new MyBinarySearchTree<T>();
        foreach (var item in this)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;

    }

    public T FindBy<K>(K key, Func<T, K, bool> predicate)
    {
        foreach (var item in this)
        {
            if (predicate(item, key))
            {
                return item;
            }
        }
        return default(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(Root).GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(TreeNode<T>? node)
    {
        if (node != null)
        {
            foreach (var value in InOrderTraversal(node.Left))
            {
                yield return value;
            }
            yield return node.Value;
            foreach (var value in InOrderTraversal(node.Right))
            {
                yield return value;
            }
        }
    }

    public IMyIterator<T> GetIterator()
    {
        throw new NotImplementedException();
    }

    public R Reduce<R>(Func<R, T, R> accumulator, R initial)
    {
        R result = initial;
        foreach (var item in this)
        {
            result = accumulator(result, item);
        }
        return result;
    }

    public void Remove(T value) => DeleteValue(this, value);

    private void DeleteValue(MyBinarySearchTree<T>? tree, T value)
    {
        // special case if the value to delete is in the root (and the root has 0 children or 1 child)
        if (tree.Root == null) return;
        
        if (value.CompareTo(tree.Root.Value) == 0)
        {
            // there are no children:
            if (tree.Root.Left == null && tree.Root.Right == null)
            {
                tree.Root = null;
                return;
            }
            // there is only left child, the right does not exist
            else if (tree.Root.Left != null && tree.Root.Right == null)
            {
                tree.Root = tree.Root.Left;
                tree.Root.Parent = null;
                return;
            }
            // there is only right child, the left does not exist
            else if (tree.Root.Left == null && tree.Root.Right != null)
            {
                tree.Root = tree.Root.Right;
                tree.Root.Parent = null;
                return;
            }
        }
        // all other cases. Find first the node corresponding to the value we want to delete
        TreeNode<T> nodeToDelete = Search(tree.Root, value);
        // actually perform the deletion
        delete(nodeToDelete);
        return;
    }

    private void delete(TreeNode<T> nodeToDelete)
    {
        // CASE 1 : LEAF
        if (nodeToDelete.Left == null && nodeToDelete.Right == null)
        {
            var parent = nodeToDelete.Parent;

            if (isLeft(nodeToDelete, parent))
                parent.Left = null;
            else
                parent.Right = null;
            
            return;
        }

        // CASE 2 : ONE CHILD
        if (nodeToDelete.Left == null || nodeToDelete.Right == null)
        {
            var parent = nodeToDelete.Parent;
            if (nodeToDelete.Left != null)
            {
                if (isLeft(nodeToDelete, parent))
                    parent.Left = nodeToDelete.Left;
                else
                    parent.Right = nodeToDelete.Left;
                nodeToDelete.Left.Parent = parent;
            }
            else
            {
                if (isLeft(nodeToDelete, parent))
                    parent.Left = nodeToDelete.Right;
                else
                    parent.Right = nodeToDelete.Right;
                nodeToDelete.Right.Parent = parent;
            }

            return;
        }

        // CASE 3 : TWO CHILDREN

        // find inordersucc == smallest element of right subtree
        var inOrdSucc = findInOrderSucc(nodeToDelete);
        // copy value to nodeToDelete
        nodeToDelete.Value = inOrdSucc.Value;
        // call recursively delete on inordersucc 
        delete(inOrdSucc);
    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? findInOrderSucc(TreeNode<T> node)
    {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }
 
    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> parent)
    {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    private TreeNode<T> Search(TreeNode<T>? node, T value)
    {
        if (node == null) // node does not exist
            return null;

        if (value.CompareTo(node.Value) == 0) // value in the node is the same we are looking for
            return node;

        if (value.CompareTo(node.Value) > 0) // value in the node is smaller than the one we are looking for
            return Search(node.Right, value);

        return Search(node.Left, value);
    }

    public void Sort(Comparison<T> comparison) //inorder travrsal
    {
        throw new NotImplementedException();
    }

    public void Update(T task) // remove the old, add the new 
    {
        throw new NotImplementedException();
    }
}