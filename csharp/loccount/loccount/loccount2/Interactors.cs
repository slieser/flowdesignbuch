using Optional;

namespace loccount
{
    public class Interactors
    {
        public static Option<IEnumerable<FileInfo>> Start(string[] args) {
            var path = CommandLine.GetPath(args);
            if(!path.HasValue) {
                return Option.None<IEnumerable<FileInfo>>();
            }
            var filenames = CodefileProvider.FindSourceFilenames(path.ValueOr(""));
            var fileInfos = Analyzer.AnalyzeFiles(filenames);
            return Option.Some(fileInfos);
        }
    }
}