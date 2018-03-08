using System;
using System.Collections.Generic;
using System.IO;

namespace loccount
{
    public class FileProvider
    {
        public void Readfile(string filename, Action<string> onLine) {
            var lines = File.ReadLines(filename);
            foreach (var line in lines) {
                onLine(line);
            }
        }

        public IEnumerable<string> Readfile(string filename) {
            var lines = File.ReadLines(filename);
            return lines;
        }
    }
}