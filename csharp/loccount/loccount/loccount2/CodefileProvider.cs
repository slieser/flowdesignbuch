using System;
using System.Collections.Generic;
using System.IO;

namespace loccount
{
    public class CodefileProvider
    {
        public static IEnumerable<string> FindSourceFilenames(string directory) {
            var filenames = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);
            return filenames;
        }

        public static void FindSourceFilenames(string directory, Action<string> onFilename, Action onFinished) {
            var filenames = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);
            foreach (var filename in filenames) {
                onFilename(filename);
            }
            onFinished();
        }
    }
}