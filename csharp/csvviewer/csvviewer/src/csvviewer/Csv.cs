using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
    public  class Csv
    {
        public static IEnumerable<Record> CreateRecords(IEnumerable<string> lines) {
            return lines.Select(s => new Record { Values = s.Split(';') });
        }
    }
}