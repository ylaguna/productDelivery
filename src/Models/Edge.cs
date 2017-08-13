namespace Models
{
    public class Edge
    {
        public int Cost { get; set; }
        public virtual Node Start { get; set; }
        public virtual Node End { get; set; }

        public Edge(Node start, Node end, int cost)
        {
            this.Start = start;
            this.End = end;
            this.Cost = cost;
        }
    }
    
}