using System;
using System.Collections.Generic;
using haushaltsbuch.contracts;

namespace haushaltsbuch
{
    public static class ConsoleUi
    {
        public static void Übersicht_anzeigen(IEnumerable<Kategorie> kategorien) {
            foreach (var kategorie in kategorien) {
                Console.WriteLine("{0}: {1:F} EUR", kategorie.Bezeichnung, kategorie.Betrag);
            }
        }

        public static void Kategorie_anzeigen(double saldo, string kategorie, double betrag) {
            Console.WriteLine("Kassenbestand: {0:F} EUR", saldo);
            Console.WriteLine("{0}: {1:F} EUR", kategorie, betrag);
        }
    }
}