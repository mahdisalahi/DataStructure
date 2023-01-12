using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Graph
{
    public class Graph<T>
    {
        public bool _isDirected = false;
        public bool _isWeighted = false;

        public Graph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }

        public List<Node<T>> Nodes { get; set; }


    }
}
