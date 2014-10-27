using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.FriendsOfPesho
{
    class FriendsOfPesho
    {
        // Everything is in one file in order to test the task in bgcoder.
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(' ');
            int allPoints = int.Parse(arguments[0]);
            int streetsNumber = int.Parse(arguments[1]);
            int hospitalsNumber = int.Parse(arguments[2]);

            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            string[] allHospitals = Console.ReadLine().Split(' ');

            for (int i = 0; i < streetsNumber; i++)
            {
                string[] streetArguments = Console.ReadLine().Split(' ');
                int firstNode = int.Parse(streetArguments[0]);
                int secondNode = int.Parse(streetArguments[1]);
                int distance = int.Parse(streetArguments[2]);

                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                Node firstNodeObj = allNodes[firstNode];
                Node secondNodeObj = allNodes[secondNode];

                if (!graph.ContainsKey(firstNodeObj))
                {
                    graph.Add(firstNodeObj, new List<Connection>());
                }

                if (!graph.ContainsKey(secondNodeObj))
                {
                    graph.Add(secondNodeObj, new List<Connection>());
                }

                graph[firstNodeObj].Add(new Connection(secondNodeObj, distance));
                graph[secondNodeObj].Add(new Connection(firstNodeObj, distance));
            }

            for (int i = 0; i < hospitalsNumber; i++)
            {
                int currentHospital = int.Parse(allHospitals[i]);
                allNodes[currentHospital].IsHospital = true;
            }

            long minSum = long.MaxValue;

            for (int i = 0; i < hospitalsNumber; i++)
            {
                int currentHospitalNum = int.Parse(allHospitals[i]);
                Node currentHospital = allNodes[currentHospitalNum];
                DijkstraAlgorithm(graph, currentHospital);

                long tempSum = 0;

                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        tempSum += node.Value.DijkstraDistance;
                    }
                }

                if (tempSum < minSum)
                {
                    minSum = tempSum;
                }
            }

            Console.WriteLine(minSum);
        }

        static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            OrderedBag<Node> priorQueue = new OrderedBag<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0;
            priorQueue.Add(source);

            while (priorQueue.Count != 0)
            {
                Node currentElement = priorQueue.RemoveFirst();

                if (currentElement.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var connection in graph[currentElement])
                {
                    var posDistance = currentElement.DijkstraDistance + connection.Distance;

                    if (posDistance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = posDistance;
                        priorQueue.Add(connection.ToNode);
                    }
                }
            }

        }
    }

    public class Node : IComparable
    {
        public long DijkstraDistance { get; set; }

        public int ID { get; set; }

        public bool IsHospital { get; set; }
        public Node(int ID)
        {
            this.ID = ID;
            IsHospital = false;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection
    {
        public Node ToNode { get; set; }

        public int Distance { get; set; }

        public Connection(Node toNode, int distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }
    }
}
