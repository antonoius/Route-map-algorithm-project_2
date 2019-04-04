using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MapAlgorithm.Roads;

namespace MapAlgorithm.Nodes
{
    class Coordinate
    {
        
        public int index   { get;  }
        public double X { get; }
        public double Y { get; }
        public double IntialDis { set; get; }
        


      //  private List<Road> Roads;
       
       public Coordinate(int id,double x, double y)
       {
         //   Roads = new List<Road>();
            this.index = id;
            this.X = x;
            this.Y = y;
            IntialDis = -1;
           
        }
        //public void AddRoad(Coordinate parent,Coordinate child,double speed , double length)
        //{
        //    Road r = new Road(parent, child, speed, length);

        //    Roads.Add(r);
        //}



        public int getIndex()
        {
            return index;
        }
     
      


    }
}
