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
            var filter = new CostOfTheRouteFilter(this._graph, nodes, this._cheapestCostOfTheRoute);
            var total = GetCostOfTheRoute.Execute(filter);

            return total == int.MaxValue ? "NO SUCH ROUTE" : total.ToString();
        }

        public string CountRoutesArriving(Node client)
        {
            var filter = new RoutesArrivingFilter(this._graph, client);
            return GetCountRoutesArriving.Execute(filter).ToString();
        }

        public string ShortestRoute(params Node[] nodes)
        {
            var filter = new ShortestRouteFilter(this._graph, nodes);
            return GetShortestRoute.Execute(filter).ToString();
        }     
        
        public string CountRoutesMaxStops(Node start, Node end, int maxStops)
        {
            var filter = CountRoutesFilter.MaxStops(this._graph, start, end, maxStops);
            return GetCountRoutes.Execute(filter).ToString();
        }

        public string CountRoutesMaxCost(Node start, Node end, int maxCost)
        {
            var filter = CountRoutesFilter.MaxCost(this._graph, start, end, maxCost);
            return GetCountRoutes.Execute(filter).ToString();
        }

        public string CountRoutesExactlyStops(Node start, Node end, int exactlyStops)
        {
            var filter = CountRoutesFilter.ExactlyStops(this._graph, start, end, exactlyStops);
            return GetCountRoutes.Execute(filter).ToString();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}