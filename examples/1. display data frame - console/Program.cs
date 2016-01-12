using DataForge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.display_data_frame___console
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            // Create a simple data frame.
            //
            var maxRange = 14;
            var dataFrame = new DataFrame(
                new IntColumn("index", Enumerable.Range(0, maxRange)),
                new DoubleColumn("Sin", Enumerable.Range(0, maxRange).Select(i => Math.Sin(i))),
                new DoubleColumn("Cos", Enumerable.Range(0, maxRange).Select(i => Math.Cos(i)))
            );

            Console.WriteLine(dataFrame.ToString());
        }
    }
}
