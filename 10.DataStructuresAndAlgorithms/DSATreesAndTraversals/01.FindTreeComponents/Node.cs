using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.FindTreeComponents
{
    public class Node<T>
    {
        public Node()
        {
            this.Children = new List<Node<T>>();
            this.HasParent = false;
            this.Father = null;
        }

        public Node(T value) : this()
        {
            this.NodeValue = value;
        }

        public bool HasParent { get; set; }

        public T NodeValue { get; set; }

        public List<Node<T>> Children { get; set; }

        public Node<T> Father { get; set; }
    }
}
