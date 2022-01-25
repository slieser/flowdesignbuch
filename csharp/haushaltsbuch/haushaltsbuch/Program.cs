namespace haushaltsbuch
{
    public static class Program
    {
        public static void Main(string[] args) {
            Interactors.Start(args,
                kategorien => ConsoleUi.Übersicht_anzeigen(kategorien),
                saldo => ConsoleUi.Kategorie_anzeigen(saldo));
        }
    }
}