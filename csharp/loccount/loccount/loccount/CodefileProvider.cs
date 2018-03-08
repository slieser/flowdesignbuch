using System;
using System.Collections.Generic;
using System.IO;

namespace loccount
{
    public class CodefileProvider
    {
        public static void GetSourcecodeFiles(string directory, Action<string> onFilename, Action onFinished) {
            var filenames = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);
            foreach (var filename in filenames) {
                onFilename(filename);
            }
            onFinished();
        }

        public static IEnumerable<string> GetSourcecodeFiles(string directory) {
            var filenames = Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories);
            return filenames;
        }
    }
}