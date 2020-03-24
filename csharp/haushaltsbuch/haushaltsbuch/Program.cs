using haushaltsbuch.logic;

namespace haushaltsbuch
{
    internal static class Program
    {
        private static void Main(string[] args) {
            Kommandozeile.Kommando_Übersicht_prüfen(args,
                a => {
                    var kategorien = Interactors.Übersicht_ausführen(a);
                    ConsoleUi.Übersicht_anzeigen(kategorien);
                },
                a => {
                    var kategorieMitSaldo = Interactors.Buchung_ausführen(a);
                    ConsoleUi.Kategorie_anzeigen(kategorieMitSaldo);
                });
        }
    }
}