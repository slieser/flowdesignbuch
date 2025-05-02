using System.Collections.Generic;

namespace loccount
{
    public class Analyzer
    {
        public static IEnumerable<FileInfo> AnalyzeFiles(IEnumerable<string> filenames) {
            foreach (var filename in filenames) {
                yield return AnalyzeFile(filename);
            }
        }

        private static FileInfo AnalyzeFile(string filename) {
            var lines = FileProvider.ReadFile(filename);
            var fileInfo = LinesOfCode.CountLines(lines, filename);
            return fileInfo;
        }
    }
}