namespace Project_v3
{
    internal class Edge
    {
        public int Source { set; get; }
        public int dis { set; get; }
        public double Kilo { set; get; }
        public double length { set; get; }
        public Edge(int s, int d, double w,double k)
        {
            Source = s;
            dis = d;
            length = w;
            Kilo = k;
            
        }
        public int GetNeighbourIndex(int nodeIndex)
        {

            if (Source == nodeIndex)
                return dis;
            else
                return Source;
        }
    }
}