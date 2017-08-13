using System;
using System.Linq;
using Models;
using Services.Dijkstra;
using Services.YRS;

namespace Services
{
    internal class ProductDeliveryService : IDisposable
    {
        private Graph _graph;

        public ProductDeliveryService(Graph graph)
        {
            this._graph = graph;
        }

        public int CostOfTheRoute(params Node[] nodes)
        {
            int total = 0;
            var before = nodes.First();
            foreach(var node in nodes)
            {
                using(var alg = new DijkstraAlgorithm(this._graph))
                {
                    total += alg.CheapestCost(before, node);
                }

                before = node;
            }

            return total;
        }
        public int ShortestRoute(params Node[] nodes)
        {
            int total = 0;
            var before = nodes.First();
            foreach(var node in nodes)
            {
                using(var alg = new DijkstraAlgorithm(this._graph))
                {
                    total += alg.ShortestPathCost(before, node);
                }

                before = node;
            }

            return total;
        }

        public int CountRoutes(Node start, Node end, int maxStops = int.MaxValue, int maxCost = int.MaxValue)
        {
            if (maxCost == int.MaxValue && maxStops == int.MaxValue)
            {
                throw new Exception("Please, select a max value or max cost or i'll be in a overflow :(");
            }

            using(var alg = new YRSAlgorithm(this._graph))
            {
                alg.SetMaxStops(maxStops);
                alg.SetMaxCost(maxCost);
                return alg.NumberOfRoutes(start, end);
            }
        }

        public int CountRoutesArriving(Node client)
        {
            return this._graph.Nodes.Sum(node => node.Routes.Any(path => path.End.Name.Equals(client.Name)) ? 1 : 0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}