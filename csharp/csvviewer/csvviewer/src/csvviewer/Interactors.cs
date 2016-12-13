using System.Collections.Generic;

namespace csvviewer
{
    public class Interactors
    {
        private readonly Paging paging = new Paging();
        private readonly CommandLine commandLine = new CommandLine();
        private readonly FileProvider fileProvider = new FileProvider();

        public IEnumerable<Record> Start(string[] args) {
            var filename = commandLine.GetFilename(args);
            var pageLength = commandLine.GetPageLength(args);
            var lines = fileProvider.ReadFileContent(filename);
            var firstPage = paging.ExtractFirstPage(lines, pageLength);
            var records = Csv.CreateRecords(firstPage);
            return records;
        }

        public IEnumerable<Record> MoveNext() {
            var pageLength = commandLine.GetPageLength();
            var lines = fileProvider.GetFileContent();
            var nextPage = paging.ExtractNextPage(lines, pageLength);
            var records = Csv.CreateRecords(nextPage);
            return records;
        }
    }
}