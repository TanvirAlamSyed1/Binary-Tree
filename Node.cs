using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace node
{
    class Node<T> where T : IComparable
    {
        private T data;
        public Node<T> Left, Right;
        public Node(T item) // constructor
        {
            data = item;
            Left = null;
            Right = null;
        }
        public T Data
        {
            set { data = value; }
            get { return data; }
        }
    }
}
