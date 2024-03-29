using System;
using System.Collections.Generic;
using haushaltsbuch.buchungsprovider;
using haushaltsbuch.contracts;
using haushaltsbuch.logic;

namespace haushaltsbuch
{
    public static class Interactors
    {
        public static void Start(string[] args, Action<IEnumerable<Kategorie>> onKategorien, Action<Saldo> onSaldo) {
            Kommandozeile.Kommando_feststellen(args,
                a => {
                    var kategorien = Übersicht_ausführen(a);
                    onKategorien(kategorien);
                },
                a => {
                    var saldo = Buchung_ausführen(a);
                    onSaldo(saldo);
                });
        }

        internal static IEnumerable<Kategorie> Übersicht_ausführen(
                    IEnumerable<string> args) {
            var monat = Kommandozeile.Monat_ermitteln(args);
            var buchungen = Buchungsprovider.Load_All();
            var kategorien = Buchhaltung.Alle_Kategorien_bilden(buchungen, monat);
            return kategorien;
        }

        internal static Saldo Buchung_ausführen(IEnumerable<string> args) {
            var buchung = Kommandozeile.Buchung_aus_Parametern_erstellen(args);
            Buchungsprovider.Save(buchung);
            var buchungen = Buchungsprovider.Load_All();

            var saldo = Buchhaltung.Saldo(buchung, buchungen);
            var kategorie = Buchhaltung.Kategorie_berechnen(buchung, buchungen);
            return new Saldo {
                TheSaldo = saldo, 
                Bezeichnung = kategorie.Bezeichnung, 
                Betrag = kategorie.Betrag
            };
        }
    }
}