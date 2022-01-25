using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace syntax.schleifen
{
    public class Csv
    {
        public List<Record> CreateRecords(List<string> lines) {
            var result = new List<Record>();

            foreach (var line in lines) {
                var record = CreateRecord(line);
                result.Add(record);
            }

            return result;
        }

        private Record CreateRecord(string line) {
            // ...
        }
    }

    public class Record
    {
    }
}