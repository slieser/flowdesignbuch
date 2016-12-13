using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
    public class Paging
    {
        public IEnumerable<string> ExtractFirstPage(IEnumerable<string> lines, int pageLength) {
            return lines.Take(pageLength + 1);
        }
    }
}