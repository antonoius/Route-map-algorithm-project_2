using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_v3
{
    class Graph
    {
        public List<Node> nodes { set; get; }
        public List<Edge> edges { set; get; }
        public List<int> Path { set; get; }
        public int NumOfNodes { set; get; }
        public int NumOfEdges { set; get; }
        public int startnode { set; get; }
        public int endnode { set; get; }
        
        public Graph(List<Edge> _edges,List<Node> _nodes,int s,int ee)
        {
            Path = new List<int>();
            edges = new List<Edge>();
            edges = _edges;
            nodes = new List<Node>();
            nodes = _nodes;
            startnode = s;
            endnode = ee;
            // this for loop to add edges to to it's nodes 
            // every edge added to 2 nodes the source node and the dictination node
            for (int e = 0; e < edges.Count; e++)
            {
                nodes[edges[e].Source].edges.Add(edges[e]);
                nodes[edges[e].dis].edges.Add(edges[e]);
            }

        }
        public void ShortesPath( )
        {
            MinHeap<Node> MHeep = new MinHeap<Node>();
            nodes[startnode].DistanceFromSource = 0;
            nodes[startnode].TotalDis = 0;
            MHeep.Insert(nodes[startnode]);
            while (MHeep.Count!=0)
            {
                Node bb = new Node();
                bb = MHeep.ExtractMin();
                int Parent= bb.index;
                double WeightParent = bb.DistanceFromSource;
                double DistanceParent = bb.TotalDis;
                List<Edge> CurrentEdges = new List<Edge>();
                CurrentEdges = nodes[Parent].edges;
                var watch2 = System.Diagnostics.Stopwatch.StartNew();
                for (int e = 0; e < CurrentEdges.Count; e++)
                {
                    int neighbourIndex = CurrentEdges[e].GetNeighbourIndex(Parent);
                    
                         if (nodes[neighbourIndex].DistanceFromSource>CurrentEdges[e].length+WeightParent)
                         {                          
                            nodes[neighbourIndex].DistanceFromSource = CurrentEdges[e].length + WeightParent;
                            nodes[neighbourIndex].TotalDis= DistanceParent + CurrentEdges[e].Kilo;
                            nodes[neighbourIndex].predeccecor = bb.index;
                            MHeep.Insert(nodes[neighbourIndex]);
                        }                   
                }
            }
        }
        public List<int> GetPath(int start, int end)
        {
            List<int> path = new List<int>();
            while (start != end) // Complextiy O(N)
            {
                start = nodes[start].predeccecor;
                path.Add(start);
            }
            return path;
        }
    }
    class MinHeap<T> where T : IComparable
    {
        private List<Node> data = new List<Node>();

        public void Insert(Node o)
        {
            data.Add(o);

            int i = data.Count - 1;
            while (i > 0)
            {
                int j = (i + 1) / 2 - 1;

                // Check if the invariant holds for the element in data[i]  
                Node v = data[j];
                if (v.DistanceFromSource.CompareTo(data[i].DistanceFromSource) < 0 || v.DistanceFromSource.CompareTo(data[i].DistanceFromSource) == 0)
                {
                    break;
                }

                // Swap the elements  
                Node tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;

                i = j;
            }
        }

        public Node ExtractMin()
        {
            if (data.Count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node min = data[0];
            data[0] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            this.MinHeapify(0);
            return min;
        }

        public Node Peek()
        {
            return data[0];
        }

        public int Count
        {
            get { return data.Count; }
        }

        private void MinHeapify(int i)
        {
            int smallest;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1) - 1 + 1;

            if (l < data.Count && (data[l].DistanceFromSource.CompareTo(data[i].DistanceFromSource) < 0))
            {
                smallest = l;
            }
            else
            {
                smallest = i;
            }

            if (r < data.Count && (data[r].DistanceFromSource.CompareTo(data[smallest].DistanceFromSource) < 0))
            {
                smallest = r;
            }

            if (smallest != i)
            {
                Node tmp = data[i];
                data[i] = data[smallest];
                data[smallest] = tmp;
                this.MinHeapify(smallest);
            }
        }
    }
}
