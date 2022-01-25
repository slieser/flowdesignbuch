using System;

namespace loccount
{
    internal class Program
    {
        public static void Main(string[] args) {
            var locStats = Interactors.Start(args);
            Ui.Show(locStats);
        }
    
        /*
        public static void Main(string[] args) {
            var path = CommandLine.GetPath(args);
            CodefileProvider.FindSourceFilenames(path,
                filename => {
                    Console.WriteLine(filename);
                },
                () => {
                    Console.WriteLine("Finished!");
                });
        }
        public static void Main(string[] args) {
            var path = CommandLine.GetPath(args);
            var filenames = CodefileProvider.FindSourceFilenames(path);
            foreach (var filename in filenames) {
                    Console.WriteLine(filename);
            }
            Console.WriteLine("Finished!");
        }
        */
    }
}