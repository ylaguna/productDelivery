using Models;

namespace Services.Resources
{
    internal class ShortestRouteFilter
    {
        public Node[] nodes;
        public Graph graph;

        public ShortestRouteFilter(Graph graph, Node[] nodes)
        {
            this.graph = graph;
            this.nodes = nodes;
        }
    }
}