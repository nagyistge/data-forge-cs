using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = 100000;
            var input = Enumerable.Range(0, max).Select(i => (float)i).ToArray();

            var swx = new Stopwatch();
            swx.Start();

            input
                .Select(i => Convert1(i))
                .Select(i => Convert1(i))
                .ToArray();

            swx.Stop();

            Console.WriteLine("No conversion = {0}ms", swx.Elapsed.TotalMilliseconds);

            var sw1 = new Stopwatch();
            sw1.Start();

            input
                .Select(i => Convert2a(i))
                .Select(i => Convert2b(i))
                .ToArray();

            sw1.Stop();

            Console.WriteLine("Boxing = {0}ms", sw1.Elapsed.TotalMilliseconds);

            var sw2 = new Stopwatch();
            sw2.Start();

            input.Select(i => Convert3(i)).ToArray();

            sw2.Stop();

            Console.WriteLine("Convertible = {0}ms", sw2.Elapsed.TotalMilliseconds);
        }

        private static object Convert3(float i)
        {
            return ((IConvertible)i).ToType(typeof(float), null);
        }

        private static object Convert2a(float i)
        {
            return (object)i;
        }

        private static float Convert2b(object i)
        {
            return (float)i;
        }

        private static float Convert1(float i)
        {
            return (float)i;
        }
    }
}
