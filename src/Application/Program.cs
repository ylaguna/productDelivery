using System;
using Domain.Models;

namespace ProductDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodeA = new Node('A');
            var nodeB = new Node('B');

            nodeA.AddRoute(nodeB, 10);
            var graph = new Graph(nodeA, nodeB);
        }
    }
}
