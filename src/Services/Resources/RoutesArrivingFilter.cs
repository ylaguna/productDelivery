using Models;

namespace Services.Resources
{
    internal class RoutesArrivingFilter
    {
        public Node client;
        public Graph graph;

        public RoutesArrivingFilter(Graph graph, Node client)
        {
            this.graph = graph;
            this.client = client;
        }
    }
}