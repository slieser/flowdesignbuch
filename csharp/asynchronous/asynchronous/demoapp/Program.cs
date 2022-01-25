using System;
using System.Threading;

namespace demoapp
{
    internal class Program
    {
        public static void Main(string[] args) {
            var timer = new Timer(o => {
                var now = DateTime.Now.ToShortTimeString();
                Console.WriteLine($"Hello from the background at {now}");
            });
            timer.Change(0, 500);
            Thread.Sleep(5000);
        }
    }
}