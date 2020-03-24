namespace haushaltsbuch
{
    internal static class Program
    {
        private static void Main(string[] args) {
            Interactors.Start(args,
                kategorien => ConsoleUi.Übersicht_anzeigen(kategorien),
                kategorieMitSaldo => ConsoleUi.Kategorie_anzeigen(kategorieMitSaldo));
        }
    }
}