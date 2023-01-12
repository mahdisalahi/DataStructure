using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Graph
{
    public class Edge<T>
    {
        public Node<T> From { get; set; }
        public Node<T> To { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return $"Node from: {From.Data} --> To: {To.Data}";
        }
    }
}
