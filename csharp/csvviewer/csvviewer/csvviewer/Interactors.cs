using System.Collections.Generic;

namespace csvviewer
{
    public class Interactors
    {
        private readonly Paging _paging = new Paging();
        private readonly CommandLine _commandLine = new CommandLine();
        private readonly FileProvider _fileProvider = new FileProvider();

        public IEnumerable<Record> Start(string[] args) {
            var filename = _commandLine.GetFilename(args);
            var pageLength = _commandLine.GetPageLength(args);
            var lines = _fileProvider.ReadFileContent(filename);
            var firstPage = _paging.ExtractFirstPage(lines, pageLength);
            var records = Csv.CreateRecords(firstPage);
            return records;
        }

        public IEnumerable<Record> FirstPage() {
            var pageLength = _commandLine.GetPageLength();
            var lines = _fileProvider.GetFileContent();
            var nextPage = _paging.ExtractFirstPage(lines, pageLength);
            var records = Csv.CreateRecords(nextPage);
            return records;
        }

        public IEnumerable<Record> PrevPage() {
            var pageLength = _commandLine.GetPageLength();
            var lines = _fileProvider.GetFileContent();
            var nextPage = _paging.ExtractPrevPage(lines, pageLength);
            var records = Csv.CreateRecords(nextPage);
            return records;
        }

        public IEnumerable<Record> NextPage() {
            var pageLength = _commandLine.GetPageLength();
            var lines = _fileProvider.GetFileContent();
            var nextPage = _paging.ExtractNextPage(lines, pageLength);
            var records = Csv.CreateRecords(nextPage);
            return records;
        }

        public IEnumerable<Record> LastPage() {
            var pageLength = _commandLine.GetPageLength();
            var lines = _fileProvider.GetFileContent();
            var nextPage = _paging.ExtractLastPage(lines, pageLength);
            var records = Csv.CreateRecords(nextPage);
            return records;
        }

        internal string GetFilename(string[] args) {
            // InternalsVisibleTo
            return args[0];
        }
    }
}