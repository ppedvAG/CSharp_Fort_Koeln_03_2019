using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTests
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> zahlen = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                zahlen.Add(i);
            }

            int sleepTime = 100;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (var item in zahlen)
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine($"Ergebnis: {item*2}");
            }
            watch.Stop();
            Console.WriteLine($"Zeit: {watch.ElapsedMilliseconds}");
            watch.Reset();
            watch.Start();
            zahlen.AsParallel().ForAll(z =>
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine($"Ergebnis: {z * 2}");
            });
            watch.Stop();
            Console.WriteLine($"Zeit AsParallel: {watch.ElapsedMilliseconds}");

            watch.Reset();
            watch.Start();
            Parallel.ForEach(zahlen, z =>
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine($"Ergebnis: {z * 2}");
            });
            watch.Stop();
            Console.WriteLine($"Zeit Parallel: {watch.ElapsedMilliseconds}");


            Console.ReadKey();
        }
    }
}