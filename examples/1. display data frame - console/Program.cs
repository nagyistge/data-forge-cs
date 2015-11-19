using Pancas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.display_data_frame___console
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            // Create a simple data frame.
            //
            var values = Enumerable.Range(0, 14)
                .Select(i => new
                {
                    index = i,
                    sin = Math.Sin(i),
                    cos = Math.Cos(i)
                })
                .ToArray();

            var columnNames = new string[] { "index", "Sin", "Cos" };
            var dataFrame = new DataFrame(columnNames, values);

            Console.WriteLine(dataFrame.ToString());
        }
    }
}
