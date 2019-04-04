using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v3
{
    class Node:IComparable
    {
        public double DistanceFromSource { set; get; }
        public double TotalDis { set; get; }
        public bool Visited { set; get; }
        public int index { set; get; }
        public int predeccecor { set; get; }
        public List<Edge> edges { set; get; }
        public Node()
        {
            index = -1;
            DistanceFromSource = double.MaxValue;
            Visited = false;
            edges = new List<Edge>();
            TotalDis = 0;
            predeccecor = -1;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
