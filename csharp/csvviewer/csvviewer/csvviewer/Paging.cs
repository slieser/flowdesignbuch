using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
    public class Paging
    {
        private int _pageNo;

        public IEnumerable<string> ExtractFirstPage(IEnumerable<string> lines, int pageLength) {
            _pageNo = 1;
            return lines.Take(pageLength + 1);
        }

        public IEnumerable<string> ExtractPrevPage(IEnumerable<string> lines, int pageLength) {
            DecrementPageNo(pageLength);
            var linesToSkip = CalculateLinesToSkip(pageLength);
            return ExtractLinesForPage(lines, pageLength, linesToSkip);
        }

        public IEnumerable<string> ExtractNextPage(IEnumerable<string> lines, int pageLength) {
            IncrementPageNo(lines, pageLength);
            var linesToSkip = CalculateLinesToSkip(pageLength);
            return ExtractLinesForPage(lines, pageLength, linesToSkip);
        }

        public IEnumerable<string> ExtractLastPage(IEnumerable<string> lines, int pageLength) {
            _pageNo = CalculateLastPageNo(lines, pageLength);
            var linesToSkip = CalculateLinesToSkip(pageLength);
            return ExtractLinesForPage(lines, pageLength, linesToSkip);
        }

        private static int CalculateLastPageNo(IEnumerable<string> lines, int pageLength) {
            return lines.Count() / pageLength + 1;
        }

        private void IncrementPageNo(IEnumerable<string> lines, int pageLength) {
            var numberOfLines = lines.Count();
            if (_pageNo * pageLength + 1 < numberOfLines) {
                _pageNo++;
            }
        }

        private void DecrementPageNo(int pageLength) {
            if ((_pageNo - 1) * pageLength + 1 > 1) {
                _pageNo--;
            }
        }

        private int CalculateLinesToSkip(int pageLength) {
            return (_pageNo - 1) * pageLength + 1;
        }

        private static IEnumerable<string> ExtractLinesForPage(IEnumerable<string> lines, int pageLength, int linesToSkip) {
            return lines
                .Take(1)
                .Union(lines.Skip(linesToSkip).Take(pageLength));
        }
    }
}