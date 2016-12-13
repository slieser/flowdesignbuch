using System.Collections.Generic;
using System.IO;

namespace csvviewer
{
    public class FileProvider
    {
        public static IEnumerable<string> ReadFileContent(string filename) {
            return File.ReadAllLines(filename);
        }
    }
}