using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using node;
using Binary_tree;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace Bs_tree
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }
        public void InsertItem(T item)
        {
            insertItem(item, ref root);// goes into the recursive function
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0) // if the data is less than the current root data
                insertItem(item, ref tree.Left);// go to the left side and carry on searching

            else if (item.CompareTo(tree.Data) > 0)//if data is greater than the current root node
                insertItem(item, ref tree.Right);// go to the right hand side of the tree

        }

        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        /*It looks at the root, if its smaller than the item, it moves left, if its bigger than the item it moves right.
         Once its found the right node, it sees if that node has an empty child node. 
        If Left is empty and right isn't, it makes right the new node.
        If Right is empty and left isn't, it makes right new node.
        Otherwise
        finds the smallest item in right
         */
        private void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                return;
            }
            if (item.CompareTo(tree.Data) < 0)
            {
                removeItem(item, ref tree.Left);
            }
            if (item.CompareTo(tree.Data) > 0)
            {
                removeItem(item, ref tree.Left);
            }
            if (item.CompareTo(tree.Data) == 0)
            {
                if (tree.Left == null & tree.Right != null)
                {
                    tree = tree.Right;
                }
                else if (tree.Right == null & tree.Left != null)
                {
                    tree = tree.Left;
                }
                else if (tree.Right != null & tree.Left != null)
                {
                    T newRoot = LeastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(newRoot, ref tree.Right);
                }
                else
                {
                    tree = null;
                }
            }
        }
        public T LeastItem(Node<T> tree) // just keeps going to the left side of the tree, until it finds it empty and returns value of the node
        {
            if (tree.Left == null)
            {
                return (tree.Data);
            }
            else
            {
                return LeastItem(tree.Left);
            }
        }

        public int FindHeight()// goes to each side of the tree, and traverses to the deepest side of the tree, returns that value
        {
            return Height(root);
        }

        private int Height(Node<T> tree)
        {
            if (tree == null)
            {
                return -1;
            }
            else
            {
                int leftHeight = Height(tree.Left);// this keeps on iterating until it hits the very last tree, which will send back the height of the left hand side
                int rightHeight = Height(tree.Right); //this keeps on iterating until it hits the very last tree, which will send back the height of the right hand side
                if (leftHeight >= rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }

            }
        }
        public int Count()
        {
            return count(root);
        }
        private int count(Node<T> tree)
        {
            int c = 1;             //Node itself should be counted
            if (tree == null)
                return 0;
            else
            {
                c += count(tree.Left); // adds itself to the count then moves to the left, till it = 0
                c += count(tree.Right);// adds itself to the count then moves to the right, till it = 0
                return c; // returns total of items in the binary search tree
            }
        }

        public bool Contain(T item)
        {
            return contain( root, item);
        }

        private bool contain( Node<T> tree, T item)
        {
           if(tree != null)// if tree is null, return false
            {
                if(item.CompareTo(tree.Data) == 0)
                {
                    return true;//if data is same as item, return true
                }
                if (item.CompareTo(tree.Data) < 0)
                {
                    return contain(tree.Left, item); //if ditem is smaller than data, go into left tree
                }
                if (item.CompareTo(tree.Data) > 0)
                {
                    return contain(tree.Right, item);//if ditem is greater than data, go into right tree
                }
            }
            return false;
        }   
    }

}