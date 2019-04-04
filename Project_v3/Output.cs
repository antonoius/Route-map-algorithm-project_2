using MapAlgorithm.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Project_v3
{
    class Output
    {
        public double TotalTime { set; get; }
        public double VDistance { set; get; }
        public double WDistance { set; get; }
        public double TotalDistance { set; get; }
        public double ExcuteTime { set; get; }
        public List<Coordinate> coordinates { set; get; }
        public List<Edge> edges { set; get; }
        public List<Node> nodes { set; get; }
        public List<int> Path { set; get; }
        public int StartNode { set; get; }
        public int EndNode { set; get; }
        public double x1 { set; get; }
        public double y1 { set; get; }
        public double x2 { set; get; }
        public double y2 { set; get; }
        public double red { set; get; }
        public string GPath { set; get; }
        public Output(string p, double _x1, double _y1, double _x2, double _y2, double _red)
        {
            coordinates = new List<Coordinate>();
            edges = new List<Edge>();
            nodes = new List<Node>();
            Path = new List<int>();
            ExcuteTime = 0;
            VDistance = 0;
            TotalDistance = 0;
            TotalTime = 0;
            WDistance = 0;
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
            red = _red;
            GPath = p;
            
        }
        public Output ()
        {
            coordinates = new List<Coordinate>();
            edges = new List<Edge>();
            nodes = new List<Node>();
            Path = new List<int>();
        }
        public Output(string p)
        {
            coordinates = new List<Coordinate>();
            edges = new List<Edge>();
            nodes = new List<Node>();
            Path = new List<int>();
            GPath = p;
        }
        public Output (string p , Output DataObj, double _x1, double _y1, double _x2, double _y2, double _red)
        {
            coordinates = new List<Coordinate>();
            edges = new List<Edge>();
            nodes = new List<Node>();
            Path = new List<int>();
            for (int i = 0; i < DataObj.coordinates.Count; i++) // Complexity O(N)
            {
                Coordinate c = new Coordinate(DataObj.coordinates[i].index, DataObj.coordinates[i].X, DataObj.coordinates[i].Y);
                coordinates.Add(c);
            }
            for (int i = 0; i < DataObj.nodes.Count; i++) // Complexity O(N)
            {
                Node n = new Node();
                n.index = i;
                nodes.Add(n);
            }
            for (int i = 0; i < DataObj.edges.Count; i++) // Complexity O(E)
            {
                Edge e = new Edge(DataObj.edges[i].Source, DataObj.edges[i].dis, DataObj.edges[i].length, DataObj.edges[i].Kilo);
                edges.Add(e);
            }
            ExcuteTime = 0;
            VDistance = 0;
            TotalDistance = 0;
            TotalTime = 0;
            WDistance = 0;
            x1 = _x1;
            x2 = _x2;
            y1 = _y1;
            y2 = _y2;
            red = _red;
            GPath = p;
        }
        public void ReadData()
        {
           
            FileStream fr = new FileStream(GPath, FileMode.Open);
            StreamReader sr = new StreamReader(fr);
              AllCoordinates.NODES.Clear();
            int NumOfNodes = int.Parse(sr.ReadLine());
            for (int i = 0; i < NumOfNodes; i++) 
            {

                string[] temp = sr.ReadLine().Split(' ');
                int node_id = int.Parse(temp[0]);
                double x = double.Parse(temp[1]);
                double y = double.Parse(temp[2]);

                Coordinate n = new Coordinate(node_id, x, y);
                coordinates.Add(n);
                Node nod = new Node();
                nod.index = i;
                nodes.Add(nod);
            }
            Node nn = new Node();            
            nodes.Add(nn);          
            Node nn2= new Node();            
            nodes.Add(nn2);

            int num_of_roads = int.Parse(sr.ReadLine());
            for (int i = 0; i < num_of_roads; i++)
            {
                string[] temp = sr.ReadLine().Split(' ');

                int parent_id = int.Parse(temp[0]); // parent node id
                int child_id = int.Parse(temp[1]);    //child node id
                double length  = double.Parse(temp[2]);
                double speed = double.Parse(temp[3]);
                double time = length / speed;
                Edge e = new Edge(parent_id, child_id, time, length);
                edges.Add(e); 
            }          
            fr.Close();
            sr.Close();
        }
        public void AddVirtualEdges()
        {
            CoordinatesOperations op = new CoordinatesOperations();
            List<Coordinate> coordinates2 = new List<Coordinate>();
            coordinates2 = op.getClosestNodes2(x1, y1, red, coordinates);
            StartNode = nodes.Count - 2;
            for (int i = 0; i < coordinates2.Count; i++)  // Complexity O(N) 
            {
                Edge e = new Edge(StartNode, coordinates2[i].index, coordinates2[i].IntialDis / 5, coordinates2[i].IntialDis);
                edges.Add(e);
            }
            EndNode = nodes.Count - 1;
            List<Coordinate> coordinates3 = new List<Coordinate>();
            coordinates3 = op.getClosestNodes2(x2, y2, red, coordinates);
            for (int i = 0; i < coordinates3.Count; i++)   // Complexity O(E)
            {
                Edge e = new Edge(EndNode, coordinates3[i].index, coordinates3[i].IntialDis / 5, coordinates3[i].IntialDis);

                edges.Add(e);
            }
        }
        public void GetMinPath()
        {
            Graph g = new Graph(edges, nodes, StartNode, EndNode);

            g.ShortesPath();
            TotalTime = (g.nodes[EndNode].DistanceFromSource * 60);

            TotalDistance = g.nodes[EndNode].TotalDis + WDistance;
            //-------------to print path

            List<int> path = new List<int>();
            path = g.GetPath(g.nodes.Count - 1, g.nodes.Count - 2);
            Path = path;
            //for (int a = path.Count - 2; a > -1; a--)
            //{
            //    Console.Write(path[a] + " ");
            //}
            //Console.WriteLine();
            double W1 = nodes[EndNode].TotalDis - nodes[path[0]].TotalDis;
            double W2 = nodes[path[path.Count - 2]].TotalDis;
            WDistance = W1 + W2;
            VDistance = TotalDistance - WDistance;
            //-------------
            //Console.WriteLine("The shortest time          : " + Math.Round(TotalTime, 2));
            //Console.WriteLine("The total distance         : " + Math.Round(TotalDistance, 2));
            //Console.WriteLine("The total walking distance : " + Math.Round(WDistance, 2));
            //Console.WriteLine("The total vehicle distance : " + Math.Round(VDistance, 2));
            //Console.WriteLine();

        }


    }
}
