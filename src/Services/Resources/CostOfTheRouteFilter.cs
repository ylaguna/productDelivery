using Models;

namespace Services.Resources
{
    public struct CostOfTheRouteFilter
    {
        public Node[] nodes;
        public bool cheapestCostOfTheRoute;
        public Graph graph;
    }
}