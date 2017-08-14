using Models;

namespace Services.Resources
{
    public class CountRoutesFilter
    {
        public Graph graph;
        public Node start;
        public Node end;
        public int maxStops;
        public int maxCost;

        public CountRoutesFilter(Graph graph, Node start, Node end, int maxStops, int maxCost)
        {
            this.graph = graph;
            this.start = start;
            this.end = end;
            this.maxCost = maxCost;
            this.maxStops = maxStops;
        }
    }
}