// public class MyBSTIterator<T> : IMyIterator<T>
// {
//     private MyBinarySearchTree<T> _tree;
//     private Stack<TreeNode<T>> _stack;

//     public MyBSTIterator(MyBinarySearchTree<T> tree)
//     {
//         _tree = tree;
//         _stack = new Stack<TreeNode<T>>();
//         PushLeft(_tree.Root);
//     }

//     private void PushLeft(TreeNode<T>? node)
//     {
//         while (node != null)
//         {
//             _stack.Push(node);
//             node = node.Left;
//         }
//     }

//     public bool HasNext()
//     {
//         return _stack.Count > 0;
//     }

//     public T Next()
//     {
//         if (!HasNext())
//             throw new InvalidOperationException("No more elements in the collection.");

//         TreeNode<T> current = _stack.Pop();
//         PushLeft(current.Right);
//         return current.Value;
//     }

//     public void Reset()
//     {
//         _stack.Clear();
//         PushLeft(_tree.Root);
//     }
// }