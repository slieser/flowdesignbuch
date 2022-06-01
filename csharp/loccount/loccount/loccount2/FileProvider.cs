using System;
using System.Collections.Generic;
using System.IO;

namespace loccount
{
    public static class FileProvider
    {
        public static IEnumerable<string> ReadFile(string filename) {
            var lines = File.ReadLines(filename);
            return lines;
        }
    }
}