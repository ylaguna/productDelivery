using System.Collections.Generic;

namespace Services.Dijkstra.Resources
{
    internal class DijkstraNode
    {
        private static readonly int Infinity = int.MaxValue;

        public char Name { get; set; }
        public int PathLegth { get; set; }
        public int PathCost { get; set; }
        public virtual DijkstraNode Predecessor { get; set; }
        public NodeStatus Status { get; set; }

        public DijkstraNode(char name)
        {
            this.Name = name;
            this.Status = NodeStatus.Temporary;
            this.Predecessor = null;
            this.PathLegth = Infinity;
            this.PathCost = Infinity;
        }

        public void MakePermanent()
        {
            this.Status = NodeStatus.Permanent;
        }

        public bool IsTemporary()
        {
            return this.Status.Equals(NodeStatus.Temporary);
        }

        public bool IsInfinity()
        {
            return this.PathCost.Equals(Infinity);
        }
    }

}