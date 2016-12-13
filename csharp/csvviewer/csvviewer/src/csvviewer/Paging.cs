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

        public IEnumerable<string> ExtractNextPage(IEnumerable<string> lines, int pageLength) {
            _pageNo++;
            var linesToSkip = (_pageNo - 1) * pageLength + 1;
            if (linesToSkip > lines.Count()) {
                _pageNo--;
                linesToSkip = (_pageNo - 1) * pageLength + 1;
            }
            return lines
                .Take(1)
                .Union(lines.Skip(linesToSkip).Take(pageLength));
        }
    }
}