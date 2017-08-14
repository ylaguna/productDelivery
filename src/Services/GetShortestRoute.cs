using System.Linq;
using Services.Interfaces;
using Services.Resources;

namespace Services
{
    internal static class GetShortestRoute
    {
        public static int Execute(ShortestRouteFilter filter)
        {
            int total = 0;
            var before = filter.nodes.First();
            foreach(var node in filter.nodes.Skip(1))
            {
                using(IShortestPathAlgorithm alg = AlgorithmFactory.ShortestPathAlgorithm(filter.graph))
                {
                    total += alg.ShortestPathCost(before, node);
                }

                before = node;
            }

            return total;
        }

    }
}