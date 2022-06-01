using System.Collections.Generic;

namespace loccount
{
    public class Interactors
    {
        public static IEnumerable<LOCstat> Start(string[] args) {
            var path = CommandLine.GetPath(args);
            var filenames = CodefileProvider.FindSourceFilenames(path);
            var locStats = Analyzer.AnalyzeFiles(filenames);
            return locStats;
        }
    }
}