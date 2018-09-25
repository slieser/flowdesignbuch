using System;
using System.Collections.Generic;

namespace haushaltsbuch
{
    public static class ConsoleUi
    {
        public static void Übersicht_anzeigen(IEnumerable<Tuple<string, double>> kategorien) {
            foreach (var tuple in kategorien) {
                Console.WriteLine("{0}: {1:F} EUR", tuple.Item1, tuple.Item2);
            }
        }

        public static void Kategorie_anzeigen(double saldo, string kategorie, double betrag) {
            Console.WriteLine("Kassenbestand: {0:F} EUR", saldo);
            Console.WriteLine("{0}: {1:F} EUR", kategorie, betrag);
        }
    }
}