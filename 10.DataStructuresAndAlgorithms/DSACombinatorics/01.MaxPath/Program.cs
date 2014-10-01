using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MaxPath
{
    class Program
    {
        static long maxSum = 0;
        static HashSet<Node> usedNodes = new HashSet<Node>(); 

        static void DFS(Node node, long currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.numberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetChild(i)))
                {
                    continue;
                }

                DFS(node.GetChild(i), currentSum);
            }

            if (node.numberOfChildren == 1 && currentSum >= maxSum)
            {
                maxSum = currentSum;
            }
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < N - 1; i++)
            {
                string[] connection = Console.ReadLine().Split(new char[] { '(', ')', '<', '-' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(connection[0]);
                int child = int.Parse(connection[1]);

                Node parentNode;
                Node childNode;

                if (nodes.ContainsKey(parent))
                {
                    parentNode = nodes[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
            }

            foreach (var node in nodes)
            {
                if (node.Value.numberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }
    }

    public class Node
    {
        private int value;
        private bool hasParent;
        private List<Node> children;

        public Node(int value)
        {
            this.Value = value;
            this.children = new List<Node>();
        }

        public int Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                this.value = value;
            }
        }

        public int numberOfChildren
        {
            get
            {
                return this.children.Count();
            }
        }

        public void AddChild(Node child)
        {
            child.hasParent = true;
            this.children.Add(child);
        }
        
        public Node GetChild(int index)
        {
            return this.children[index];
        }

    }
}
