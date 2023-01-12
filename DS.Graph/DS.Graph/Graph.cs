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

        private void UpdateIndex()
        {
            var i = 0;
            Nodes.ForEach(x => x.Index = i++);
        }

        public Node<T> AddNode(T value)
        {
            var node = new Node<T>() { Data = value };
            UpdateIndex();
            Nodes.Add(node);
            return node;
        }
    }
}
