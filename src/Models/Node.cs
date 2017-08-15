using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Node
    {
        public char Name { get; set; }

        public List<Edge> Routes { get; set; }

        public Node(char name)
        {
            this.Name = name;
            this.Routes = new List<Edge>();
        }

        public void AddRoute(Node destination, int cost)
        {
            var path = new Edge(this, destination, cost);
            this.Routes.Add(path);
        }

    }

}