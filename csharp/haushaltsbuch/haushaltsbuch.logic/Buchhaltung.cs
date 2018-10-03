using System;
using System.Collections.Generic;
using System.Linq;
using haushaltsbuch.contracts;

namespace haushaltsbuch.logic
{
    public static class Buchhaltung
    {
        public static double Saldo(Buchung buchung, IEnumerable<Buchung> buchungen) {
            var saldo = 0.0;

            var buchungen_bis_datum = buchungen.Where(b => b.Buchungsdatum <= buchung.Buchungsdatum);

            foreach (var b in buchungen_bis_datum) {
                if (b.Buchungstyp == Buchungstypen.Einzahlung) {
                    saldo += b.Betrag;
                }
                if (b.Buchungstyp == Buchungstypen.Auszahlung) {
                    saldo -= b.Betrag;
                }
            }

            return saldo;
        }

        public static (string kategorie, double betrag) Kategorie_berechnen(Buchung buchung, IEnumerable<Buchung> buchungen) {
            var buchungen_der_kategorie = buchungen
                .Where(b => b.Buchungstyp == Buchungstypen.Auszahlung &&
                            b.Kategorie == buchung.Kategorie &&
                            b.Buchungsdatum.Month == buchung.Buchungsdatum.Month &&
                            b.Buchungsdatum.Year == buchung.Buchungsdatum.Year);
            var betrag = buchungen_der_kategorie.Sum(b => b.Betrag);
            return (buchung.Kategorie, betrag);
        }

        public static IEnumerable<Tuple<string, double>> Alle_Kategorien_bilden(IEnumerable<Buchung> buchungen, DateTime monat) {
            var nach_kategorie_gruppierte_buchungen = buchungen
                .Where(b => b.Buchungstyp == Buchungstypen.Auszahlung &&
                            b.Buchungsdatum.Month == monat.Month &&
                            b.Buchungsdatum.Year == monat.Year)
                .GroupBy(b => b.Kategorie);
            return nach_kategorie_gruppierte_buchungen
                .Select(kategorie => new Tuple<string, double>(kategorie.Key, kategorie.Sum(b => b.Betrag)));
        }
    }
}