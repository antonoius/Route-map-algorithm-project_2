using Project_v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MapAlgorithm.Roads;
namespace MapAlgorithm.Nodes
{
    class CoordinatesOperations
    {
        private int SORTX = 0;
        private int SORTY = 1;
        public double calcDist(double x1,double y1,double x2,double y2)
        {
            double X1 = Math.Abs(x1 - x2);
            double Y1 = Math.Abs(y1-y2);
            double X = X1 * X1;
            double Y = Y1 * Y1;
            return Math.Sqrt(X + Y);         
        }
        public Coordinate getClosestNode(double x,double y, double radius)
        {
            double minDist = double.MaxValue;
            //double radius1 = radius / 1000;
            Coordinate closestNode = new Coordinate(-1,-1,-1);
            for (int i = 0; i < AllCoordinates.NODES.Count; i++)
            {
                double distance = calcDist(x,y, AllCoordinates.NODES[i].X, AllCoordinates.NODES[i].Y);
            


                if (distance < minDist)
                {
                    minDist = distance;
                    closestNode = AllCoordinates.NODES[i];
                }
             //   Console.WriteLine(closestNode);
               
            }
            if (minDist > radius)
                return new Coordinate(-2,-2,-2);
            else

            return closestNode;
        }
        public List<Coordinate> getClosestNodes(double x, double y, double radius)
        {
            double minDist = double.MaxValue;
            List<Coordinate> closestNode = new List<Coordinate>();
            for (int i = 0; i < AllCoordinates.NODES.Count; i++)
            {
                double distance = calcDist(x, y, AllCoordinates.NODES[i].X, AllCoordinates.NODES[i].Y);


                if (distance < radius)
                {
                    AllCoordinates.NODES[i].IntialDis = distance;
                    closestNode.Add(AllCoordinates.NODES[i]);
                }
            }
            return closestNode;

        }
        public List<Coordinate> getClosestNodes2(double x, double y, double radius,List<Coordinate> Coordinates)
        {
            double minDist = double.MaxValue;
            List<Coordinate> closestNode = new List<Coordinate>();
            for (int i = 0; i < Coordinates.Count; i++)
            {
                double distance = calcDist(x, y, Coordinates[i].X, Coordinates[i].Y);
                if (distance < radius/1000)
                {
                  Coordinates[i].IntialDis = distance;
                  closestNode.Add(Coordinates[i]);
                }
            }
            return closestNode;
        }
    }
}
