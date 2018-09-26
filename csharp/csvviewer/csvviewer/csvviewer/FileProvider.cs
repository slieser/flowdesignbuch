using System.Collections.Generic;
using System.IO;

namespace csvviewer
{
    public class FileProvider
    {
        private string[] _lines;

        public IEnumerable<string> ReadFileContent(string filename) {
            _lines = File.ReadAllLines(filename);
            return _lines;
        }

        public IEnumerable<string> GetFileContent() {
            return _lines;
        }
    }
}