using System;

namespace loccount
{
    internal class Program
    {
        public static void Main1(string[] args) {
            var directory = CommandLine.GetDirectory(args);
            CodefileProvider.GetSourcecodeFiles(directory,
                onFilename: filename => {
                    Console.WriteLine(filename);
                },
                onFinished: () => {
                    Console.WriteLine("Finished!");
                });
        }

        public static void Main(string[] args) {
            var directory = CommandLine.GetDirectory(args);
            var filenames = CodefileProvider.GetSourcecodeFiles(directory);
            foreach (var filename in filenames) {
                Console.WriteLine(filename);
            }
            Console.WriteLine("Finished!");
        }
    }
}