using System.Linq;
using Models;
using Services.Dijkstra;
using Services.Interfaces;
using Services.Resources;

namespace Services
{
    internal static class GetCostOfTheRoute
    {

        public static int Execute(CostOfTheRouteFilter filter)
        {
            int total = 0;
            var before = filter.nodes.First();
            foreach(var node in filter.nodes.Skip(1))
            {
                int cost;
                if (filter.cheapestCostOfTheRoute)
                {
                    using(IShortestPathAlgorithm alg = AlgorithmFactory.ShortestPathAlgorithm(filter.graph))
                    {
                        cost = alg.CheapestCost(before, node);
                    }

                }
                else
                {
                    var pathToNode = before.Routes.FirstOrDefault(path => path.End.Name.Equals(node.Name));

                    if (pathToNode == null)
                        return int.MaxValue;

                    cost = pathToNode.Cost;
                }

                total += cost;
                before = node;
            }

            return total;
        }
    }
}