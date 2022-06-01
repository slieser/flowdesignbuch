using System.Collections.Generic;
using System.Linq;

namespace loccount
{
    public static class LinesOfCode
    {
        public static LOCstat CountLines(IEnumerable<string> lines, string filename) {
            var locStat = new LOCstat();
            locStat.Filename = filename;
            locStat.Total = lines.Count();
            locStat.Loc = lines.Count(IsCodeLine);
            return locStat;
        }

        private static bool IsCodeLine(string line) {
            return !string.IsNullOrWhiteSpace(line) && !line.TrimStart().StartsWith("//");
        }
    }
}