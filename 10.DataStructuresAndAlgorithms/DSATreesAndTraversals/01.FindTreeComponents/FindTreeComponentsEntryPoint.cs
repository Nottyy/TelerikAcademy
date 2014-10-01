using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _01.FindTreeComponents
{
    class FindTreeComponentsEntryPoint
    {
        static HashSet<string> allPaths = new HashSet<string>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Node<int>[] nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < N - 1; i++)
            {
                string commandLine = Console.ReadLine();
                string[] splittedCommandLine = commandLine.Split(' ');

                var parentNodeID = int.Parse(splittedCommandLine[0]);
                var childNodeID = int.Parse(splittedCommandLine[1]);

                nodes[parentNodeID].Children.Add(nodes[childNodeID]);
                nodes[childNodeID].HasParent = true;
                nodes[childNodeID].Father = nodes[parentNodeID];
            }


            // 1.Find the root.

            Node<int> rootNode = FindRootNode(N, nodes);
            Console.WriteLine("The root node is: {0}", rootNode.NodeValue);

            // 2.Find all leafs.
            var leafs = FindAllLeafs(N, nodes);
            Console.Write("All leaf nodes are: ");
            for (int i = 0; i < leafs.Count; i++)
            {
                Console.Write("{0}, ", leafs[i].NodeValue);
            }
            Console.WriteLine();

            // 3.Find all middle nodes.
            List<Node<int>> middleNodes = FindAllMiddleNodes(N, nodes);
            Console.Write("All middle nodes are: ");
            for (int i = 0; i < middleNodes.Count; i++)
            {
                Console.Write("{0}, ", middleNodes[i].NodeValue);
            }
            Console.WriteLine();

            // 4.Find the longest path in the tree.
            var longestPath = FindLongestPath(FindRootNode(N, nodes));
            Console.WriteLine("The longest path is: {0}", longestPath);

            // 5*.Find all paths in a tree with given sum S of their nodes.
            FindAllPathsWithSumS(nodes, N, 9);

            // 6*.Find all sub trees with given sum S of their nodes.
            Console.WriteLine("All SubTrees with given sum 12 are: ");
            BFSFindAllSubTreesWithGivenSum(nodes, rootNode, 12);
        }

        private static void BFSFindAllSubTreesWithGivenSum(Node<int>[] nodes, Node<int> rootNode, int searchedSum)
        {
            Queue<Node<int>> queue = new Queue<Node<int>>();
            var currentSum = 0;

            foreach (var node in nodes)
            {
                if (node == rootNode)
                {
                    continue;
                }

                List<int> currentSubTree = new List<int>();
                queue.Enqueue(node);
                currentSum = 0;

                while (queue.Count > 0)
                {
                    Node<int> currentNode = queue.Dequeue();
                    currentSum += currentNode.NodeValue;
                    currentSubTree.Add(currentNode.NodeValue);

                    foreach (var child in currentNode.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

                if (currentSum == searchedSum)
                {
                    Console.WriteLine(string.Join(" ", currentSubTree));
                }
            }

        }

        private static void FindAllPathsWithSumS(Node<int>[] nodes, int N, int searchedSum)
        {
            for (int i = 0; i < N; i++)
            {
                var currentNode = nodes[i];
                var visitedNodes = new bool[N];
                visitedNodes[currentNode.NodeValue] = true;
                var currentSteps = new List<int>();
                currentSteps.Add(currentNode.NodeValue);
                var currentSum = currentNode.NodeValue;
                FindAllPathsWithSumSForGivenNode(currentNode, visitedNodes, currentSteps, currentSum, searchedSum);
            }

            Console.WriteLine("All paths in the tree with sum {0} are:", searchedSum);
            foreach (var item in allPaths)
            {
                Console.WriteLine(item);
            }
        }

        private static void FindAllPathsWithSumSForGivenNode(Node<int> currentNode,
            bool[] visitedNodes, List<int> currentSteps, int currentSum, int searchedSum)
        {
            if (currentSum == searchedSum)
            {
                currentSteps.Sort();
                allPaths.Add(string.Join(" ", currentSteps));
            }
            else if (currentSum > searchedSum)
            {
                return;
            }

            if (currentNode.Children.Count > 0)
            {

                foreach (var node in currentNode.Children)
                {
                    if (!visitedNodes[node.NodeValue])
                    {
                        visitedNodes[node.NodeValue] = true;
                        currentSteps.Add(node.NodeValue);
                        FindAllPathsWithSumSForGivenNode(node, visitedNodes, currentSteps, currentSum + node.NodeValue, searchedSum);
                        visitedNodes[node.NodeValue] = false;
                        currentSteps.Remove(node.NodeValue);
                    }
                }
            }

            if (currentNode.HasParent == true)
            {
                if (!visitedNodes[currentNode.Father.NodeValue])
                {
                    visitedNodes[currentNode.Father.NodeValue] = true;
                    currentSteps.Add(currentNode.Father.NodeValue);

                    FindAllPathsWithSumSForGivenNode(currentNode.Father, visitedNodes,
                        currentSteps, currentSum + currentNode.Father.NodeValue, searchedSum);

                    visitedNodes[currentNode.Father.NodeValue] = false;
                    currentSteps.Remove(currentNode.Father.NodeValue);
                }
            }
        }

        private static int FindLongestPath(Node<int> root)
        {
            int longestPath = 0;
            if (root.Children.Count == 0)
            {
                return 0;
            }

            foreach (var node in root.Children)
            {
                longestPath = Math.Max(longestPath, FindLongestPath(node));
            }

            return longestPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(int N, Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            for (int i = 0; i < N; i++)
            {
                if (nodes[i].Children.Count > 0 && nodes[i].HasParent == true)
                {
                    middleNodes.Add(nodes[i]);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllLeafs(int N, Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();
            for (int i = 0; i < N; i++)
            {
                if (!(nodes[i].Children.Count > 0))
                {
                    leafs.Add(nodes[i]);
                }
            }

            return leafs;
        }

        private static Node<int> FindRootNode(int N, Node<int>[] nodes)
        {
            for (int i = 0; i < N; i++)
            {
                if (nodes[i].HasParent == false)
                {
                    var rootNode = nodes[i];
                    return rootNode;
                }
            }

            throw new ArgumentException("There is no root!");
        }
    }
}
