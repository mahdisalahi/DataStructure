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

        public void RemoveNode(Node<T> node)
        {
            Nodes.Remove(node);

            UpdateIndex();

            foreach (var item in Nodes)
            {
                RemoveEdge(item, node);
            }
        }

        public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
        {
            from.Neighbors.Add(to);
            if (_isWeighted)
            {
                from.Weights.Add(weight);
            }

            if (!_isDirected)
            {
                to.Neighbors.Add(from);
                if (_isWeighted)
                {
                    to.Weights.Add(weight);
                }
            }
        }

        public void RemoveEdge(Node<T> from, Node<T> to)
        {
            var index = from.Neighbors.FindIndex(x => x == to);
            from.Neighbors.RemoveAt(index);
            if (_isWeighted)
            {
                from.Weights.RemoveAt(index);
            }
        }

        public List<Edge<T>> GetEdges()
        {
            var edges = new List<Edge<T>>();
            foreach (var from in Nodes)
            {
                for (int i = 0; i < from.Neighbors.Count; i++)
                {
                    var edge = new Edge<T>()
                    {
                        From = from,
                        To = from.Neighbors[i],
                        Weight = _isWeighted ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }

            return edges;
        }

        public Edge<T> this[int from, int to]
        {
            get
            {
                var nodeFrom = Nodes[from];
                var nodeTo = Nodes[to];

                var index = nodeFrom.Neighbors.IndexOf(nodeTo);

                if (index >= 0)
                {
                    var edge = new Edge<T>()
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = _isWeighted ? nodeFrom.Weights[index] : 0
                    };

                    return edge;
                }

                return null;
            }
        }
    }

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
