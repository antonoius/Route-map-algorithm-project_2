using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v3
{
    class TestClass
    {
        public static double TimeWithoutReadingData { set; get; }
        public static double TimeWithReadingData { set; get; }
        public static void ReadQ(string PathOfQuery,string PathOfInput)
        {
            double AlgoTime=0 ;           
            FileStream fr = new FileStream(PathOfQuery, FileMode.Open);
            StreamReader sr = new StreamReader(fr);

            Stopwatch TotalWatch = new Stopwatch();
            TotalWatch.Start();
            Output data_obj = new Output(PathOfInput);
            data_obj.ReadData();
                
            int NumOfQ = int.Parse(sr.ReadLine());
            for (int i = 0; i < NumOfQ; i++) // Complexity O(N)
            {

                string[] temp = sr.ReadLine().Split(' ');
                double x1 = double.Parse(temp[0]);
                double y1 = double.Parse(temp[1]);
                double x2 = double.Parse(temp[2]);
                double y2 = double.Parse(temp[3]);
                double red = int.Parse(temp[4]);

                Output e = new Output(PathOfInput,data_obj,x1,y1,x2,y2,red);
                e.AddVirtualEdges();
                Stopwatch ss = new Stopwatch();
                ss.Start();
                 e.GetMinPath();
                AlgoTime += ss.ElapsedMilliseconds;
                ss.Stop();
                double W1 = e.nodes[e.EndNode].TotalDis - e.nodes[e.Path[0]].TotalDis;
                double W2 = e.nodes[e.Path[e.Path.Count - 2]].TotalDis;
                
                e.VDistance = e.TotalDistance - e.WDistance;
                FileStream stream = new FileStream(@"Final Samples\Large2.txt", FileMode.Append);
                StreamWriter writer = new StreamWriter(stream);
                for (int a = e.Path.Count - 2; a > -1; a--)
                {
                    writer.Write(e.Path[a] + " ");
                }
                writer.WriteLine();
                writer.WriteLine(Math.Round(e.TotalTime, 2 ) + " mins");
                writer.WriteLine(Math.Round(e.TotalDistance, 2)+ " km");
                writer.WriteLine(Math.Round(W1 + W2, 2) + " km");
                writer.WriteLine(Math.Round(e.VDistance, 2) + " km");
                writer.WriteLine();
                writer.Close();
            }

            TotalWatch.Stop();
            TimeWithoutReadingData = AlgoTime;
            TimeWithReadingData = TotalWatch.ElapsedMilliseconds;
            Console.WriteLine("Algo time is  : "+ AlgoTime);
            Console.WriteLine("Total time is : "+ TotalWatch.ElapsedMilliseconds.ToString());
            FileStream stream2 = new FileStream(@"Final Samples\Large2.txt", FileMode.Append);
            StreamWriter writer2 = new StreamWriter(stream2);
            writer2.WriteLine(AlgoTime + " ms");
            writer2.WriteLine();
            writer2.WriteLine(TotalWatch.ElapsedMilliseconds.ToString() + " ms");
            writer2.Close();


        }
        public static int TestAll(string PathOfQuery, string PathOfInput,string PathOfOutput)
        {
            List<int> errorQ = new List<int>();
            List<int> seccussQ = new List<int>();
            int counter = 0;
            FileStream fr = new FileStream(PathOfQuery, FileMode.Open);
            StreamReader sr = new StreamReader(fr);
            FileStream fr2 = new FileStream(PathOfOutput, FileMode.Open);
            StreamReader sr2 = new StreamReader(fr2);
            Stopwatch s = new Stopwatch();
            Output data_obj = new Output(PathOfInput);
            data_obj.ReadData();
            int NumOfQ = int.Parse(sr.ReadLine());
            for (int i = 0; i < NumOfQ; i++)
            {
                string[] temp = sr.ReadLine().Split(' ');
                double x1 = double.Parse(temp[0]);
                double y1 = double.Parse(temp[1]);
                double x2 = double.Parse(temp[2]);
                double y2 = double.Parse(temp[3]);
                double red = int.Parse(temp[4]);
                Output e = new Output(PathOfInput, data_obj, x1, y1, x2, y2, red);
                e.AddVirtualEdges();
                Stopwatch ss = new Stopwatch();
                ss.Start();
                 e.GetMinPath();                
                ss.Stop();
                string[] PathIds= sr2.ReadLine().Split(' ');
                Console.WriteLine(PathIds.Count()+ "  "+e.Path.Count);
                string [] output= sr2.ReadLine().Split(' ');
                if (double.Parse(output[0]) == Math.Round(e.TotalTime, 2))
                {
                    counter++;
                    seccussQ.Add(i + 1);
                }
                else
                    errorQ.Add(i + 1);
                sr2.ReadLine(); sr2.ReadLine(); sr2.ReadLine(); sr2.ReadLine();
            }
            Console.WriteLine("--------------Seccuss queries----------");
            for (int i = 0; i < seccussQ.Count; i++)
            {
                Console.Write(seccussQ[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("--------------Error queries----------");
            for (int i = 0; i < errorQ.Count; i++)
            {
                Console.Write(errorQ[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            return counter;
        }
        public static int TestLarg (string PathOfQuery, string PathOfInput, string PathOfOutput)
        {
            List<int> errorQ = new List<int>();
            List<int> seccussQ = new List<int>();
            int counter = 0;
            FileStream fr = new FileStream(PathOfQuery, FileMode.Open);
            StreamReader sr = new StreamReader(fr);

            FileStream fr2 = new FileStream(PathOfOutput, FileMode.Open);
            StreamReader sr2 = new StreamReader(fr2);
            Stopwatch s = new Stopwatch();
            Output data_obj = new Output(PathOfInput);
            data_obj.ReadData();
            int NumOfQ = int.Parse(sr.ReadLine());
            for (int i = 0; i < NumOfQ; i++)
            {
                Console.WriteLine(i);
                string[] temp = sr.ReadLine().Split(' ');
                double x1 = double.Parse(temp[0]);
                double y1 = double.Parse(temp[1]);
                double x2 = double.Parse(temp[2]);
                double y2 = double.Parse(temp[3]);
                double red = int.Parse(temp[4]);
                Output e = new Output(PathOfInput, data_obj, x1, y1, x2, y2, red);
                e.AddVirtualEdges();
                Stopwatch ss = new Stopwatch();
                ss.Start();
                e.GetMinPath();
                ss.Stop();
                string[] output2 = sr2.ReadLine().Split(' ');
               // sr2.ReadLine();
                string[] output = sr2.ReadLine().Split(' ');
                if (double.Parse(output[0]) == Math.Round(e.TotalTime, 2))
                {
                    counter++;
                    seccussQ.Add(i + 1);
                }
                else
                    errorQ.Add(i + 1);

                sr2.ReadLine();
                sr2.ReadLine();
                sr2.ReadLine();
                sr2.ReadLine();


            }
            Console.WriteLine("--------------Seccuss queries----------");
            for (int i = 0; i < seccussQ.Count; i++)
            {
                Console.Write(seccussQ[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("--------------Error queries----------");
            for (int i = 0; i < errorQ.Count; i++)
            {
                Console.Write(errorQ[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");

            return counter;
        }
    }
}
