using System;
using System.Collections.Generic;
using System.Linq;
using haushaltsbuch.contracts;

namespace haushaltsbuch.logic
{
    public static class Kommandozeile
    {
        internal static Func<DateTime> _now = () => DateTime.Now;

        public static void Kommando_feststellen(IEnumerable<string> args,
            Action<IEnumerable<string>> onÜbersichtKommando,
            Action<IEnumerable<string>> onAnderesKommando) {
            if (args.First().ToLower() == "übersicht") {
                onÜbersichtKommando(args.Skip(1));
            }
            else {
                onAnderesKommando(args);
            }
        }

        public static Buchung Buchung_aus_Parametern_erstellen(IEnumerable<string> args) {
            var tuple = Buchung_zu_Kommando_erstellen(args);
            tuple = Datum_übernehmen(tuple.Buchung, tuple.Args);
            tuple = Betrag_übernehmen(tuple.Buchung, tuple.Args);
            tuple = Kategorie_übernehmen(tuple.Buchung, tuple.Args);
            tuple = Memo_übernehmen(tuple.Buchung, tuple.Args);

            return tuple.Buchung;
        }

        public static DateTime Monat_ermitteln(IEnumerable<string> args) {
            var monat = int.Parse(args.First());
            var jahr = int.Parse(args.ElementAt(1));
            return new DateTime(jahr, monat, DateTime.DaysInMonth(jahr, monat));
        }

        internal static (Buchung Buchung, string[] Args) Buchung_zu_Kommando_erstellen(IEnumerable<string> args) {
            var buchung = new Buchung {
                Buchungstyp = BuchungstypenConverter.FromString(args.First())
            };
            return (buchung, args.Skip(1).ToArray());
        }

        internal static (Buchung Buchung, string[] Args) Datum_übernehmen(Buchung buchung, IEnumerable<string> args) {
            if (DateTime.TryParse(args.First(), out var buchungsdatum)) {
                buchung.Buchungsdatum = buchungsdatum;
                return (buchung, args.Skip(1).ToArray());
            }

            buchung.Buchungsdatum = _now();
            return (buchung, args.ToArray());
        }

        internal static (Buchung Buchung, string[] Args) Betrag_übernehmen(Buchung buchung, IEnumerable<string> args) {
            buchung.Betrag = double.Parse(args.First());
            return (buchung, args.Skip(1).ToArray());
        }

        internal static (Buchung Buchung, string[] Args) Kategorie_übernehmen(Buchung buchung, IEnumerable<string> args) {
            if (args.Any()) {
                buchung.Kategorie = args.First();
                return (buchung, args.Skip(1).ToArray());
            }
            return (buchung, args.ToArray());
        }

        internal static (Buchung Buchung, string[] Args) Memo_übernehmen(Buchung buchung, IEnumerable<string> args) {
            if (args.Any()) {
                buchung.Memo = args.First();
                return (buchung, args.Skip(1).ToArray());
            }
            return (buchung, args.ToArray());
        }
    }
}