using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v3
{
    class Program
    {
        static void Main(string[] args)
        {


            string MidInput = @"Final Samples\[2] Medium Cases\OLMap.txt";
            string MidQ = @"Final Samples\[2] Medium Cases\OLQueries.txt";
            string MidOut = @"Final Samples\[2] Medium Cases\OLOutput.txt";

            string SampleINput = @"Final Samples\[1] Sample Cases\map5.txt";
            string SampleQ = @"Final Samples\[1] Sample Cases\queries5.txt";
            string SampleOut = @"Final Samples\[1] Sample Cases\output5.txt";


            string LargQ = @"Final Samples2\[3] Large Cases\NAQueries.txt";
            string LargInput = @"Final Samples2\[3] Large Cases\NAMap.txt";
            string LargOutput = @"Final Samples\[3] Large Cases\SFOutput.txt";



          //    TestClass.ReadQ(LargQ,LargInput);
              TestClass.ReadQ(SampleQ,SampleINput);
          //  TestClass.ReadQ(MidQ, MidInput);
            //    Console.WriteLine(TestClass.TestAll(SampleQ, SampleINput, SampleOut).ToString());
             //   Console.WriteLine( TestClass.TestAll(MidQ, MidInput, MidOut).ToString());
            //   Console.WriteLine(TestClass.TestAll(LargQ, LargInput, LargOutput).ToString());
              

        }

    }


}
    



