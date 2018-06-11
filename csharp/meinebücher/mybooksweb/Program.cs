using System;
using Nancy.Hosting.Self;

namespace mybooksweb
{
    internal class Program
    {
        public static void Main(string[] args) {
            const int port = 8080;
            var url = $"http://localhost:{port}";
            using (var host = new NancyHost(new Uri(url))) {
                host.Start();
                Console.WriteLine($"Running on {url}");
                Console.Write("Press <Enter> to stop...");
                Console.ReadLine();
            }       
            Console.WriteLine("Webserver stopped.");

        }
    }
}