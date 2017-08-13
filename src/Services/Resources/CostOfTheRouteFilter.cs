using Models;

namespace Services.Resources
{
    public class CostOfTheRouteFilter
    {
        public Node[] nodes;
        public bool cheapestCostOfTheRoute;
        public Graph graph;

        public CostOfTheRouteFilter(Graph graph, Node[] nodes, bool cheapestCostOfTheRoute)
        {
            this.graph = graph;
            this.nodes = nodes;
            this.cheapestCostOfTheRoute = cheapestCostOfTheRoute;
        }
    }
}