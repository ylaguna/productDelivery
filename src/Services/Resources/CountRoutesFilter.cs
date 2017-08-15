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
        public int? exactlyStops;

        private CountRoutesFilter(Graph graph, Node start, Node end)
        {
            this.graph = graph;
            this.start = start;
            this.end = end;
            this.maxStops = int.MaxValue;
            this.maxCost = int.MaxValue;
            this.exactlyStops = null;
        }        

        public static CountRoutesFilter MaxCost(Graph graph, Node start, Node end, int value)
        {
            var filter = new CountRoutesFilter(graph, start, end);
            filter.maxCost = value;

            return filter;
        }

        public static CountRoutesFilter MaxStops(Graph graph, Node start, Node end, int value)
        {
            var filter = new CountRoutesFilter(graph, start, end);
            filter.maxStops = value;

            return filter;
        }

        public static CountRoutesFilter ExactlyStops(Graph graph, Node start, Node end, int value)
        {
            var filter = new CountRoutesFilter(graph, start, end);
            filter.exactlyStops = value;
            filter.maxStops = value;
            return filter;
        }
    }
}