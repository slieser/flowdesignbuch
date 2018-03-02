using System;
using System.Threading;

namespace nebenläufigkeit
{
    public class ClassForF
    {
        public void f(int x, Action<int> onResult) {
            Console.WriteLine("Calling A...");
            A(x, onResult);
            Console.WriteLine("A finished");
        }

        private void A(int x, Action<int> onResult) {
            var y = x + 42;

            Console.WriteLine("Calling B on new thread...");
            var thread = new Thread(() => {
                var z = B(y);
                onResult(z);
            });
            thread.Start();
            Console.WriteLine("B finished");
        }

        private int B(int y) {
            Console.WriteLine("B is working...");
            Thread.Sleep(1000);  // Simulate long running calculation
            Console.WriteLine("B did its work");
            return y + 1;
        }
    }
}