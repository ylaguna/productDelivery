using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Dijkstra.Resources
{
    internal class DijkstraGraph
    {
        public DijkstraGraph()
        {
            this.Edges = new List<DijkstraEdge>();
            this.Nodes = new List<DijkstraNode>();
        }

        public List<DijkstraNode> Nodes { get; set; }
        public List<DijkstraEdge> Edges { get; set; }

        public DijkstraNode GetSmallestTemporaryNode()
        {
            return Nodes.Where(c => c.IsTemporary()).OrderBy(node => node.PathLegth).First();
        }

        public List<DijkstraEdge> GetAdjacentRoutes(DijkstraNode node)
        {
            var adjacents = Edges
                            .Where(edge => edge.StartName.Equals(node.Name))
                            .ToList();
            
            return adjacents;
        }

        public DijkstraNode GetNodeByName(char name)
        {
            return Nodes.Find(node => node.Name.Equals(name));
        }
    }
}