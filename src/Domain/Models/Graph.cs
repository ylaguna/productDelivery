using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Graph
    {
        public virtual List<Node> Nodes { get; set; }

        public Graph(params Node[] nodes)
        {
            this.Nodes = nodes.ToList();
        }

        public Graph(List<Node> nodes)
        {
            this.Nodes = nodes;
        }
    }
}