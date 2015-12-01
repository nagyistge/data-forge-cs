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
                new Column<int>("index", Enumerable.Range(0, maxRange)),
                new Column<double>("Sin", Enumerable.Range(0, maxRange).Select(i => Math.Sin(i))),
                new Column<double>("Cos", Enumerable.Range(0, maxRange).Select(i => Math.Cos(i)))
            );

            Console.WriteLine(dataFrame.ToString());
        }
    }
}
