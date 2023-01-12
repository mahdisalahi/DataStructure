using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Graph
{
    public class Node<T>
    {
        public int Index { get; set; }
        public T Data { get; set; }
        public List<Node<T>> Neighbors { get; set; }
        public List<int> Weights { get; set; }
        public override string ToString()
        {
            return $"node with index: {Index}, Neighbors: {Neighbors.Count}";
        }
    }
}
