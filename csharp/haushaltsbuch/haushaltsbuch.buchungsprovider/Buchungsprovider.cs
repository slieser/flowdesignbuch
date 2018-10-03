using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using haushaltsbuch.contracts;

namespace haushaltsbuch.buchungsprovider
{
    public static class Buchungsprovider
    {
        private const string Filename = "buchungen.csv";

        public static void Save(Buchung buchung) {
            var csv_data = string.Format("{0};{1:d};{2:F};'{3}';'{4}'",
                BuchungstypenConverter.AsString(buchung.Buchungstyp),
                buchung.Buchungsdatum,
                buchung.Betrag,
                buchung.Kategorie,
                buchung.Memo);
            File.AppendAllLines(Filename, new[] { csv_data });
        }

        public static IEnumerable<Buchung> Load_All() {
            var csv_lines = File.ReadAllLines(Filename);
            var alle_buchungen = csv_lines.Select(Buchung_aus_CSV_erstellen);
            return alle_buchungen;
        }

        private static Buchung Buchung_aus_CSV_erstellen(string csv_line) {
            var values = csv_line.Split(';');

            return new Buchung {
                Buchungstyp = BuchungstypenConverter.FromString(values[0]),
                Buchungsdatum = DateTime.Parse(values[1]),
                Betrag = double.Parse(values[2]),
                Kategorie = values[3].Trim(new[] { '\'' }),
                Memo = values[4].Trim(new[] { '\'' })
            };
        }
    }
}