using System;
using System.Threading;
using NUnit.Framework;

namespace asynchronous
{
    [TestFixture]
    public class AsynchDemos
    {
        [Test]
        public void ExplicitThread() {
            var thread1 = new Thread(() => { DoSomething(1); });
            var thread2 = new Thread(() => { DoSomething(2); });
            var thread3 = new Thread(() => { DoSomething(3); });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            
            Thread.Sleep(5000);
        }

        [Test]
        public void ImplicitThreadWithTimer() {
            var timer = new System.Timers.Timer(200);
            timer.Elapsed += (o, e) => {
                Console.WriteLine("Hello from the background");
            };
            timer.Enabled = true;
            Thread.Sleep(5000);
        }
        
        private void DoSomething(int threadNo) {
            do {
                Console.WriteLine($"Hello from thread {threadNo}");
                Thread.Sleep(100);
            } while (true);
        }
    }
}