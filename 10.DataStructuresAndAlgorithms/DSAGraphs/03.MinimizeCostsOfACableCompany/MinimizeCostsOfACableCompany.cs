using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.MinimizeCostsOfACableCompany
{
    class MinimizeCostsOfACableCompany
    {
        static void Main(string[] args)
        {
            Dictionary<HouseNode, List<CableConnection>> graph = new Dictionary<HouseNode, List<CableConnection>>();
            var firstHouse = new HouseNode(1);
            var secondHouse = new HouseNode(2);
            var thirdHouse = new HouseNode(3);
            var fourthHouse = new HouseNode(4);
            var fifthHouse = new HouseNode(5);

            graph.Add(firstHouse, new List<CableConnection>());
            graph[firstHouse].Add(new CableConnection(secondHouse, 5));
            graph[firstHouse].Add(new CableConnection(thirdHouse, 1));
            graph[firstHouse].Add(new CableConnection(fourthHouse, 2));

            graph.Add(secondHouse, new List<CableConnection>());
            graph[secondHouse].Add(new CableConnection(firstHouse, 5));
            graph[secondHouse].Add(new CableConnection(thirdHouse, 20));
            graph[secondHouse].Add(new CableConnection(fifthHouse, 1));

            graph.Add(thirdHouse, new List<CableConnection>());
            graph[thirdHouse].Add(new CableConnection(firstHouse, 1));
            graph[thirdHouse].Add(new CableConnection(secondHouse, 20));
            graph[thirdHouse].Add(new CableConnection(fourthHouse, 4));

            graph.Add(fourthHouse, new List<CableConnection>());
            graph[fourthHouse].Add(new CableConnection(firstHouse, 2));
            graph[fourthHouse].Add(new CableConnection(secondHouse, 3));
            graph[fourthHouse].Add(new CableConnection(thirdHouse, 4));
            graph[fourthHouse].Add(new CableConnection(fifthHouse, 1));

            graph.Add(fifthHouse, new List<CableConnection>());
            graph[fifthHouse].Add(new CableConnection(secondHouse, 1));
            graph[fifthHouse].Add(new CableConnection(fourthHouse, 1));

            for (int i = 0; i < graph.Count; i++)
            {
                var sourceHouse = graph.Keys.Skip(i).First();
                DijkstraFindMinCableLengthBetweenHouses(graph, sourceHouse);
                Console.WriteLine("Starting source house with ID -> {0}", sourceHouse.HouseID);

                for (int j = 0; j < graph.Count; j++)
                {
                    var currenctHouse = graph.Keys.Skip(j).First();
                    if (currenctHouse != sourceHouse)
	                {
		                Console.WriteLine("The min cable length path to house with ID -> {0} is {1}.", currenctHouse.HouseID, currenctHouse.MinCableLenth);
	                }
                }
                Console.WriteLine();
            }
        }

        static void DijkstraFindMinCableLengthBetweenHouses(Dictionary<HouseNode, 
            List<CableConnection>> graph, HouseNode houseToStartFrom)
        {
            OrderedBag<HouseNode> houseQueue = new OrderedBag<HouseNode>();

            foreach (var house in graph)
            {
                house.Key.MinCableLenth = int.MaxValue;
            }

            houseToStartFrom.MinCableLenth = 0;
            houseQueue.Add(houseToStartFrom);

            while (houseQueue.Count > 0)
            {
                var currentHouse = houseQueue.RemoveFirst();

                if (currentHouse.MinCableLenth == int.MaxValue)
                {
                    break;
                }

                foreach (var connection in graph[currentHouse])
                {
                    var currentCableLength = currentHouse.MinCableLenth + connection.CableLenth;
                    if (connection.House.MinCableLenth > currentCableLength)
                    {
                        connection.House.MinCableLenth = currentCableLength;
                        houseQueue.Add(connection.House);
                    }
                }
            }
        }
    }
}
