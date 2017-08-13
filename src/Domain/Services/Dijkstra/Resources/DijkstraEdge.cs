namespace Domain.Services.Dijkstra.Resources
{
    internal class DijkstraEdge
    {
        public int Cost { get; set; }
        public char StartName { get; set; }
        public char EndName { get; set; }

        public DijkstraEdge(char startName, char endName, int cost)
        {
            this.StartName = startName;
            this.EndName = endName;
            this.Cost = cost;
        }
    }
}