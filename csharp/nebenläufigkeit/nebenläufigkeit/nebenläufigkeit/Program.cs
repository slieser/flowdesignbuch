using System;

namespace nebenläufigkeit
{
    class Program
    {
        static void Main(string[] args) {
            var c = new ClassForF();
            
            Console.WriteLine("Calling F...");
            c.f(7, z => Console.WriteLine($"z = {z}"));
            Console.WriteLine("F finished");

            Console.ReadLine();
        }
    }
}