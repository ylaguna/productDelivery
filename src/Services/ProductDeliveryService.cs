using System;
using System.Linq;
using Models;
using Services.Dijkstra;
using Services.Resources;
using Services.YRS;

namespace Services
{
    internal class ProductDeliveryService : IDisposable
    {
        private Graph _graph;
        public bool _cheapestCostOfTheRoute;

        public ProductDeliveryService(Graph graph)
        {
            this._graph = graph;
            this._cheapestCostOfTheRoute = false;
        }

        public string CostOfTheRoute(params Node[] nodes)
        {
            var filter = new CostOfTheRouteFilter
            {
                cheapestCostOfTheRoute = this._cheapestCostOfTheRoute,
                graph = this._graph,
                nodes = nodes
            };

            var total = GetCostOfTheRoute.Execute(filter);

            return total == int.MaxValue ? "NO SUCH ROUTE" : total.ToString();
        }

        public string CountRoutesArriving(Node client)
        {
            return this.GetCountRoutesArriving(client).ToString();
        }

        public string CountRoutes(Node start, Node end, int maxStops = int.MaxValue, int maxCost = int.MaxValue)
        {
            return this.GetCountRoutes(start, end, maxStops, maxCost).ToString();
        }

        public string ShortestRoute(params Node[] nodes)
        {
            return this.GetShortestRoute(nodes).ToString();
        }

        private int GetShortestRoute(params Node[] nodes)
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

        private int GetCountRoutes(Node start, Node end, int maxStops = int.MaxValue, int maxCost = int.MaxValue)
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

        private int GetCountRoutesArriving(Node client)
        {
            return this._graph.Nodes.Sum(node => node.Routes.Any(path => path.End.Name.Equals(client.Name)) ? 1 : 0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}