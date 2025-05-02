using System;

namespace loccount
{
    internal class Program
    {
        public static void Main(string[] args) {
            var fileInfos = Interactors.Start(args);
            if(!fileInfos.HasValue) {
                Console.WriteLine("No path provided.");
                return;
            }
            Ui.Show(fileInfos.ValueOr(Array.Empty<FileInfo>()));
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