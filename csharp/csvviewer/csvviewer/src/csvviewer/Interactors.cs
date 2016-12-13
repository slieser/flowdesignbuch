using System.Collections.Generic;

namespace csvviewer
{
    public class Interactors
    {
        private readonly Paging paging = new Paging();

        public IEnumerable<Record> Start(string[] args) {
            var filename = CommandLine.GetFilename(args);
            var pageLength = CommandLine.GetPageLength(args);
            var lines = FileProvider.ReadFileContent(filename);
            var firstPage = paging.ExtractFirstPage(lines, pageLength);
            var records = Csv.CreateRecords(firstPage);
            return records;
        }
    }
}