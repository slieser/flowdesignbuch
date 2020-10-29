using System.Collections.Generic;

namespace loccount
{
    public class Analyzer
    {
        public static IEnumerable<LOCstat> AnalyzeFiles(IEnumerable<string> filenames) {
            foreach (var filename in filenames) {
                yield return AnalyzeFile(filename);
            }
        }

        private static LOCstat AnalyzeFile(string filename) {
            var lines = FileProvider.ReadFile(filename);
            var locStat = LinesOfCode.CountLines(lines, filename);
            return locStat;
        }
    }
}